# open the binary file in read mode
# 1 nibble = 4 bits
# 1 byte = 8 bits
# 4 bytes = 32 bits
# 32 bits is Integer


# first 14 bytes is header

filename = "mypicture.bmp"
outputfilename = "brightmypicture.bmp"

with open (filename, "rb") as handler:
    file_header = handler.read(14)
    print (file_header, type(file_header))

    file_type = file_header[0:2].decode()     # first 2 bytes
    print("File Type:", file_type)

    file_size = int.from_bytes(file_header [2:6], 'little')
    print("File size:", file_size)
    
    reserved_one = int.from_bytes(file_header [6:8], 'little')
    reserved_two = int.from_bytes(file_header [8:10], 'little')
    offset = int.from_bytes(file_header [10:14], 'little')
    print ("Reserved one:", reserved_one)
    print ("Reserved two:", reserved_two)
    print ("Offset:", offset)

    dip_header = handler.read(40) 
    dip_size = int.from_bytes (dip_header[0:4], 'little')
    print ("DIP Size:", dip_size)

    width = int.from_bytes (dip_header [4:8], 'little')
    height = int.from_bytes (dip_header [8:12], 'little')
    print ("Image Size in pizels:", width, "x", height)

    planes = int.from_bytes(dip_header [12:14], 'little')
    print ("Planes:", planes)

    bit_count = int.from_bytes (dip_header[14:16], 'little')
    print("Bits per pixel:", bit_count)




   # unpadded_row_size = (width * (bit_count // 3)) 
   # unpadded_row_size = (unpadded_row 3) 


    row_size = ((width *(bit_count // 3)) + 3) & ~3
    print ("Row size (in bytes):", row_size)

    handler.seek(offset)   # now at 54 bytes
    pixel_data = [] 
    for index in range(height):
        row = handler.read (row_size)
        pixel_data.append(row)

bytes_per_pixes = bit_count // 8
# increase brightness of image
for y in range (height):
    row = pixel_data[height - y - 1]  # 459th row is the actual first row
    new_row = bytearray()
    
    for x in range (width):
        start_index = x * bytes_per_pixes
        end_index = start_index + bytes_per_pixes
        pixel = row [start_index:end_index]
        if (len(pixel) == 3):
            b, g, r = pixel 
            r = min(255, int(r * 50))
            g = min(255, int(g * 50))
            b = min(255, int(b * 50))
            new_row.extend ((b, g, r))
    
    pixel_data [height - y - 1] = new_row

with open (outputfilename, "wb") as handler:
    handler.write (file_header)
    handler.write (dip_header)
    for row in pixel_data:
        handler.write (row.ljust(row_size, b'\x00')) 

