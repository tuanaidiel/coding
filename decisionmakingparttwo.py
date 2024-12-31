#No1 Identify positive, negative and zero
x = -10
if (x > 0):
    print("x is positive")

else:
    if(x == 0):
        print("x is zero")
    else:
        print("x is negative")

#2nd condition
x = 0
if (x >= 0):
    if (x == 0):
        print("x is zero")
    else:
        print("x is positive")

else:
    print("x is negative")

#3rd condition
x = 10
if (x == 0):
    print("x is zero")

else:
    if(x > 0):
        print("x is positive")
    else:
        print("x is negative")

#No2 Using elif
x = -10
if (x == 0):
    print("x is zero")

elif(x > 0):
        print("x is positive")
else:
        print("x is negative")

#No3
op = input ("enter operation: ")
x=10
y=5

result= x + y if (op == "+") else x - y if (op == "-") else x * y if (op == "*") else x / y 
print (result)

#No4
op = input ("enter operation: ")
x = "Television"

result = id(x) if (op == "A") else type(x) if (op == "D") else len(x)
print(result)
