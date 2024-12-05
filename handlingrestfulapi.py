# to open the restful api url
from urllib.request import urlopen 
# the restful api will give us JSON data
# which need to be converted into ist of dictionary in python
import json
# we want to write the json data into a csv file
import csv



url = "https://jsonplaceholder.typicode.com/posts"
response = urlopen(url) 
data = response.read()
#print (type (data)) # '["apple", "orange", "mango"]'

for post in data:
    print ("Post Id:", post["id"])
    print ("Post Id:", post["userId"])
    print ("Post Id:", post["title"])
    print ("Post Id:", post["post"])

url = "https://jsonplaceholder.typicode.com/posts"
response = urlopen(url)
data = json.loads (response.read())

try:
    with open ("jsonplaceholder.csv", "wt", newline='') as handler:
        csv_writer = csv.writer(handler, delimiter="|")

        for post in data:
            id, userId, title, body = post.values()
            body =  body.replace ("\n", " ").replace ("\r", "")
            csv_writer.writerow ([id, userId, title, body])

except Exception as e:
    print("Something went wrong", e)

