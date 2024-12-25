from userinput import keyboardInput
# pip install mysql-connector-python
import mysql.connector as mysql

def getDbConnection(host, username, password, database):
   connection = mysql.connect(
        host = host,
        user = username,
        password = password,
        database = database)
   return connection

def createProducts(connection):
    productname = keyboardInput("Product Name: ", str, "Product Name must be string")
    quantity = keyboardInput("Quantity: ", int, "Quantity must be integer")
    price = keyboardInput("Price: ", float, "Price must be float")
    try:
        SQL = f"""INSERT INTO PRODUCTS (name, quantity, price) 
        VALUES ('{productname}', '{quantity}', '{price}')"""
        cursor = connection.cursor()
        cursor.execute(SQL)
        # to make it permanently inserted call commit method
        connection.commit()
    except:
        print("Not able to append a product")

def listProducts(connection):
    try:
        SQL = "SELECT id, name, quantity, price FROM products"
        # In python, to execute SQL, you must create cursor drom connection
        cursor = connection.cursor()
        cursor.execute(SQL)
        # now the data is in cursor
        print("=" * 85)
        print(f"{'Id':10s}{'Name':40s}{'Quantity':>15s}{'Price':>20s}")
        print("=" * 85)
        for id, name, quantity, price in cursor:
            print(f"{int(id):<10d}{name:40s}{int(quantity):15d}{float(price):20.2f}")
        print("=" * 85)
    except Exception as e:             
        print("Not able to read the file", e)

def editProduct(connection):
    productid = keyboardInput("Enter product id: ", str, "Product Id must be integer")
    SQL = f"SELECT id, name, quantity, price FROM products WHERE id = {productid}"
    cursor = connection.cursor()
    cursor.execute(SQL)
    try:    
        (id, name, quantity, price) = cursor.fetchone()
    except:
        print("Product for this Id does not exist")
    else:
        name = keyboardInput(f"Product Name [{name}]: ", str, "Product Name must be string", name)
        quantity = keyboardInput(f"Quantity [{quantity}]: ", int, "Quantity must be integer", quantity)
        price = keyboardInput(f"Price [{price}]: ", float, "Price must be float", price)
        SQL = f"""UPDATE products SET name = '{name}', quantity = {quantity}, price = {price} 
        WHERE id = {id}""" 
        cursor = connection.cursor()
        cursor.execute(SQL)
        connection.commit() 

def deleteProduct(connection):
    productid = keyboardInput("Enter product id: ", str, "Product Id must be integer")
    SQL = f"SELECT id, name, quantity, price FROM products WHERE id = {productid}"
    cursor = connection.cursor()
    cursor.execute(SQL)
    try:    
        (id, name, quantity, price) = cursor.fetchone()
    except:
        print("Product for this Id does not exist")
    else:
        print(f"Product: {name}")
        print(f"Quantity: {quantity}")
        print(f"Price: {price}")
        confirm = keyboardInput("Are you sure (Y/N):", str, "cpnfirm must be strong")
        if (confirm == "Y"):
            SQL = f"DELETE FROM products where id = {id}"
            cursor = connection.cursor()
            cursor.execute(SQL)
            connection.commit() 

def doMenu(connection):
    choice = -1
    while (choice != 0):
        print("======================")
        print("| 1. List Products   |")
        print("| 2. Create Products |")
        print("| 3. Edit Product    |")
        print("| 4. Delete Product  |")
        print("| 0. Exit            |")
        print("======================")
        choice = keyboardInput("Enter your choice: ", int, "Choice must be integer")
        if (choice == 1):
            listProducts(connection)
        elif (choice == 2):
            createProducts(connection)
        elif (choice == 3):
            editProduct(connection)
        elif (choice == 4):
            deleteProduct(connection)
        elif (choice == 0):
            print("Thank you")
        else:
            print("Choice can be 0,1,2 only")

connection = getDbConnection("localhost", "root", "", "ecatalog")
doMenu(connection)