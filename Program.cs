using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace BloodMixerParser
{
    public class BloodMixerRecord
    {
        public string SerialNumber { get; set; }
        public int DataNumber { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public string DonationNumber { get; set; }
        public string BloodType { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string DonorId { get; set; }
        public string RegNumber { get; set; }
        public string BloodBagNumber { get; set; }
        public string BloodBagLot { get; set; }
        public string StaffId { get; set; }
        public int Preset { get; set; }
        public decimal BloodMl { get; set; }
        public decimal BloodGr { get; set; }
        public decimal TotalGr { get; set; }
        public TimeSpan ElapsedTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string DeviceId { get; set; }
        public string ManagerId { get; set; }
        public string TeamId { get; set; }
        public string SiteId { get; set; }
        public int Rpm { get; set; }
        public decimal Ratio { get; set; }
        public string AlarmMark { get; set; }
        public string BloodBagLabelCheck { get; set; }
        public string SampleLabelCheck { get; set; }
        public string Note { get; set; }
        public string Remark { get; set; }
        public string UserNote { get; set; }
    }

    public class BloodMixerParser
    {
        public List<BloodMixerRecord> ParseCsvFile(string filePath)
        {
            var records = new List<BloodMixerRecord>();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Error: File not found!");
                return records;
            }

            var lines = File.ReadAllLines(filePath);

            if (lines.Length < 2)
            {
                Console.WriteLine("Error: CSV file is empty or missing data.");
                return records;
            }

            for (int i = 1; i < lines.Length; i++)
            {
                var record = ParseRecord(lines[i]);
                if (record != null)
                    records.Add(record);
            }

            return records;
        }

        private BloodMixerRecord ParseRecord(string recordLine)
        {
            try
            {
                var values = recordLine.Split(';').Select(v => v.Trim()).ToArray();

                // Debug: Print the number of columns detected
                Console.WriteLine($"Processing Record: {recordLine}");
                Console.WriteLine($"Column Count: {values.Length}");

                if (values.Length < 30)  // Ensure at least 30 columns exist
                {
                    Console.WriteLine("ERROR: Missing columns in the CSV record. Skipping...");
                    return null;
                }

                // Handle multiple date formats
                DateTime.TryParseExact(values[2].Trim(),
                    new[] { "MM-dd-yyyy", "M-d-yyyy", "yyyy-MM-dd" },
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime date);

                // Handle expiry date
                DateTime? expiryDate = null;
                if (!string.IsNullOrWhiteSpace(values[6]) && DateTime.TryParse(values[6].Trim(), out DateTime tempDate))
                {
                    expiryDate = tempDate;
                }

                // Remove unwanted characters
                values[9] = values[9].Replace("=%", "").Trim();
                values[10] = values[10].Replace("=%", "").Trim();

                return new BloodMixerRecord
                {
                    SerialNumber = values[0],
                    DataNumber = int.TryParse(values[1].Trim(), out int dataNumber) ? dataNumber : 0,
                    Date = date,
                    StartTime = TimeSpan.TryParse(values[3].Trim(), out TimeSpan startTime) ? startTime : TimeSpan.Zero,
                    DonationNumber = values[4],
                    BloodType = values[5],
                    ExpiryDate = expiryDate,
                    DonorId = values[7],
                    RegNumber = values[8],
                    BloodBagNumber = values[9],
                    BloodBagLot = values[10],
                    StaffId = values[11],
                    Preset = int.TryParse(values[12].Trim(), out int preset) ? preset : 0,
                    BloodMl = decimal.TryParse(values[13].Trim(), out decimal bloodMl) ? bloodMl : 0,
                    BloodGr = decimal.TryParse(values[14].Trim(), out decimal bloodGr) ? bloodGr : 0,
                    TotalGr = decimal.TryParse(values[15].Trim(), out decimal totalGr) ? totalGr : 0,
                    ElapsedTime = TimeSpan.TryParse(values[16].Trim(), out TimeSpan elapsedTime) ? elapsedTime : TimeSpan.Zero,
                    EndTime = TimeSpan.TryParse(values[17].Trim(), out TimeSpan endTime) ? endTime : TimeSpan.Zero,
                    DeviceId = values[18],
                    ManagerId = values[19],
                    TeamId = values[20],
                    SiteId = values[21],
                    Rpm = int.TryParse(values[22].Trim(), out int rpm) ? rpm : 0,
                    Ratio = decimal.TryParse(values[23].Trim(), out decimal ratio) ? ratio : 0,
                    AlarmMark = values[24],
                    BloodBagLabelCheck = values[25],
                    SampleLabelCheck = values[26],
                    Note = values[27],
                    Remark = values[28],
                    UserNote = values.Length > 29 ? values[29] : string.Empty
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing record: {ex.Message}");
                return null;
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            try
            {
                string filePath = "76010140-20240527-151540.csv"; // Ensure correct file path
                var parser = new BloodMixerParser();
                var records = parser.ParseCsvFile(filePath);

                if (records.Count == 0)
                {
                    Console.WriteLine("No valid records found.");
                    return;
                }

                Console.WriteLine("\nExtracted Records:");
                foreach (var record in records)
                {
                    Console.WriteLine($"Date: {record.Date:MM-dd-yyyy}, Start Time: {record.StartTime}, " +
                                      $"Blood ML: {record.BloodMl}, Total GR: {record.TotalGr}");
                }

                Console.WriteLine("\nProcessing completed. Press any key to exit...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.ReadKey();
            }
        }
    }
}
