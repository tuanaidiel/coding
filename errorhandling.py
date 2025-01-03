# handle runtime error

try:
    principle = int (input ("Enter principle amount (RM): ")) #may cause problem

except:
    print ("Principle amount must be just number") #executed when error occurs

else:
    print ("Principle amount is ok") #executed when no error occurs

finally:
    print ("Thank you")  #always get executed

period = int (input ("Enter the period (years): "))
rate = int (input ("Enter the interest rate (%): "))

interest = (principle * period * rate) / 100
print ("Interest:", interest)

print ("--------------------------------------------------------------")

isErrorInput = True

while (isErrorInput):
    try:
        principle = int (input ("Enter the principle amount: "))

    except:
        print ("Principle amount must be number")

    else:
        isErrorInput = False

print ("Principle amount:", principle)