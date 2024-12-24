from userinput import keyboardInput
import mysql.connector as mysql


def getDbConnection(host, username, password, database):
    connection = mysql.connect(
        host=host,
        user=username,
        password=password,
        database=database)
    return connection

def createRoomType(connection):
    room_type = keyboardInput("Room Type: ", str, "Room Type must be a string")
    quantity = keyboardInput("Quantity: ", int, "Quantity must be an integer")
    try:
        SQL = f"""INSERT INTO room_types (room_type, quantity) 
                VALUES ('{room_type}', {quantity})"""
        cursor = connection.cursor()
        cursor.execute(SQL)
        connection.commit()
    except Exception as e:
        print("Not able to append a room type", e)

def listRoomTypes(connection):
    try:
        SQL = "SELECT id, room_type, quantity FROM room_types"
        cursor = connection.cursor()
        cursor.execute(SQL)
        print("=" * 45)
        print(f"{'Id':5s}{'Room Type':20s}{'Quantity':>15s}")
        print("=" * 45)
        for id, room_type, quantity in cursor:
            print(f"{int(id):<5d}{room_type:20s}{int(quantity):15d}")
        print("=" * 45)
    except Exception as e:
        print("Not able to read the room types", e)

def editRoomType(connection):
    room_id = keyboardInput("Enter room type id: ", int, "Room Type Id must be an integer")
    SQL = f"SELECT id, room_type, quantity FROM room_types WHERE id = {room_id}"
    cursor = connection.cursor()
    cursor.execute(SQL)
    try:
        (id, room_type, quantity) = cursor.fetchone()
    except:
        print("Room type for this Id does not exist")
    else:
        room_type = keyboardInput(f"Room Type [{room_type}] : ", str, "Room Type must be a string", room_type)
        quantity = keyboardInput(f"Quantity [{quantity}]: ", int, "Quantity must be an integer", quantity)
        SQL = f"""UPDATE room_types SET room_type = '{room_type}', quantity = {quantity}
                    WHERE id = {id}"""
        cursor = connection.cursor()
        cursor.execute(SQL)
        connection.commit()

def deleteRoomType(connection):
    room_id = keyboardInput("Enter room type id: ", int, "Room Type Id must be an integer")
    SQL = f"SELECT id, room_type, quantity FROM room_types WHERE id = {room_id}"
    cursor = connection.cursor()
    cursor.execute(SQL)
    try:
        (id, room_type, quantity) = cursor.fetchone()
    except:
        print("Room type for this Id does not exist")
    else:        
        print(f"Room Type: {room_type}")
        print(f"Quantity: {quantity}")
        confirm = keyboardInput("Are you sure (Y/N): ", str, "Confirm must be a string")
        if (confirm == "Y"):
            SQL = f"DELETE FROM room_types where id = {id}"
            cursor = connection.cursor()
            cursor.execute(SQL)
            connection.commit()

def doMenu(connection):
    choice = -1
    while (choice != 0):
        print("======================")
        print("| 1. List Room Types  |")
        print("| 2. Create Room Type |")
        print("| 3. Edit Room Type   |")
        print("| 4. Delete Room Type |")
        print("| 0. Exit             |")
        print("======================")
        choice = keyboardInput("Enter your choice: ", int, "Choice must be an integer")
        if (choice == 1):
            listRoomTypes(connection)
        elif (choice == 2):
            createRoomType(connection)
        elif (choice == 3):
            editRoomType(connection)
        elif (choice == 4):
            deleteRoomType(connection)
        elif (choice == 0):
            print("Thank you")
        else:
            print("Choice can be [0, 1, 2, 3, 4] only")

connection = getDbConnection("localhost", "root", "", "projectdetail")
doMenu(connection)

