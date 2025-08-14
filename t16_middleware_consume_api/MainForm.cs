using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.Json;

namespace LISMiddleware
{
    public partial class MainForm : Form
    {
        private readonly HttpClient _httpClient;
        private DataGridView _dataGridView;

        public MainForm()
        {
            InitializeComponent();
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:5001/")
                // adjust Url as needed
            };
        }

        private void InitializeComponent()
        {
            _dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            var button = new Button
            {
                Text = "Fetch Patients",
                Dock = DockStyle.Top
            };
            button.Click += async (s, e) => await FetchPatientAsync();

            Controls.Add(_dataGridView);
            Controls.Add(button);
            Size = new System.Drawing.Size(800, 400);
        }


        private async Task FetchPatientAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/patient");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var patients = JsonSerializer.Deserialize<List<Patient>>(json);

                _dataGridView.DataSource = patients;
            }
            catch (Exception ex)
            {
                MessaeBox.Show($"Error fetching patients: {ex.Message}");
            }
        }


        private class Patient
        {
            public Guid Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Gender { get; set; }
            public string MedicalRecordNumber { get; set; }
        }
    }
}