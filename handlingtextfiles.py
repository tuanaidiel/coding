# 1. to create a file, we use mode (x)
# If the file already exist, it will throw error
# 2. To write into a file, we use mode (w)
# 3. To append data inside the file, we use mode (a)
# 4. To read data inside the file, we use mode (r)

# t stand for text file
# b stand for binary file

from os import path
from userinput import keyboardInput

filename = "products.dat"

# 1st method
def create (filename):
    if not path.exists (filename):
        try:
            handler = open(filename, "xt")
            handler.close()
            createcolumns (filename)

        except:
            print("Sorry unable to create the file")

        
# 2nd method
def createcolumns (filename):    
    try:
        with open(filename, "wt") as handler:
            handler.write ("Product Name|Quantity|Price") 

    except:
        print ("Not able to create the column header")


def createproducts (filename):
    productname = keyboardInput ("Product Name: ", str, "Product Name must be string")
    quantity = keyboardInput ("Quantity: ", int, "Quantity must be Integer")
    price = keyboardInput ("Price: ", float, "Price must be Float")

    try:
        with open(filename, "at") as handler:
            handler.write (f"\n{productname}|{quantity}|{price}")

    except:
        print ("Not able to append a product")


def listproducts (filename):
    try:
        with open (filename, "rt") as handler:
            content = handler.readlines ()
            print ('=' * 67)
            for index, data in enumerate(content):
                product, quantity, price = data.strip().split ("|")
                if (index == 0):
                    print (f"{product:40s}{quantity:>12s}{price:>15s}")
                    print ('=' * 67)

                else:
                    print (f"{product:40s}{int(quantity):12d}{float(price):15.2f}")
            print ('=' * 67)

    except Exception as e:
        print ("Not able to read the file", e)


def editproduct (filename):
    try:
        with open (filename, "rt") as handler:
            products = handler.readlines()
        producttoedit = keyboardInput ("Enter product to edit: ", str, "Product must be string")
        productindex = None
        for index, item in enumerate (products):
            product, quantity, price = item.strip().split("|")
            if (product == producttoedit): 
                productindex = index
                break
            
        if (productindex != None):

            productname = keyboardInput (f"Product Name [{product}]: ", str, "Product Name must be string", product)
            quantity = keyboardInput (f"Quantity [{quantity}]: ", int, "Quantity must be Integer", quantity)
            price = keyboardInput (f"Price [{price}]: ", float, "Price must be Float", price)
            products[productindex] = f"{productname}|{quantity}|{price}\n"
            products [-1] = products[-1].strip()

            with open (filename, "wt") as handler:
                handler.writelines(products)

        else:
            print ("Product not found")

    except Exception as e:
        print ("An error occured while updating the product", e)


def deleteproduct (filename):
    try:
        with open (filename, "rt") as handler:
            products = handler.readlines()
        producttoedit = keyboardInput ("Enter product to delete: ", str, "Product must be string")
        productindex = None
        for index, item in enumerate (products):
            product, quantity, price = item.strip().split("|")
            if (product == producttoedit): 
                productindex = index
                break
            
        if (productindex != None):
            print (f"Product: {product}")
            print (f"Quantity: {quantity}")
            print (f"Price: {price}")
            confirm = keyboardInput ("Are you sure (Y/N): ", str, "Confirm must be string")
            if (confirm == "Y"):
                del products[productindex]
                products [-1] = products[-1].strip()
                with open (filename, "wt") as handler:
                    handler.writelines(products)

        else:
            print ("Product not found")

    except Exception as e:
        print ("An erro occured while deleting product", e)


def domenu():
    choice = -1
    while (choice != 0):
        print("=======================")
        print("| 1. List Products    |")
        print("| 2. Create Product   |")
        print("| 3. Edit Product     |")
        print("| 4. Delete Product   |")
        print("| 0. Exit             |")
        print("=======================") 
        choice = keyboardInput ("Enter your choice: ", int, "Choice must be integer")
        if (choice == 1):
            listproducts(filename)
        elif (choice == 2):
            createproducts(filename)
        elif (choice == 3):
            editproduct(filename) 
        elif (choice == 4):
            deleteproduct(filename) 
        elif (choice == 0):
            print("Thank you")
        else:
            print("Choice can be [0, 1, 2, 3] only")


create (filename) 
domenu()
#createproducts (filename)
#listproducts (filename)









