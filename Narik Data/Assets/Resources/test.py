import urllib.request
import json
import pandas as pd
import pprint
import csv

#get data
def get_data():
	with urllib.request.urlopen("https://api.thingspeak.com/channels/959724/feeds.json?results=2") as url:
		data = url.read()
		# print(data)
		# Convert data bytes ke json
		databaru = data.decode('utf8')
		return databaru

def convert_data_to_file():
	#simpen datanya ke file
	with open('mydata.json', 'w') as file:
		json.dump(databaru,file)
	return True
def parsing_json():
	f = open('data.json','r') 
	data = str(f.read())
	data = data.replace('\\','')
	data = data[1:-1]
	f.close()

	w = open('data_beauty.json','w+')
	w.write(data)
	w.close()

def rehan():
	df = pd.read_json(r'mydata.json')
	with open('mydata.json') as f: 
	    data = json.load(f)
	    print(json.dumps(data, indent = 4))
	    pprint.pprint(data)
	    df = pd.DataFrame(data)
	    print(df)
	    data.to_csv('mydata.csv', index = None)
	    print(data)
	print(df)
	df.to_csv(r'mydata.csv', index = None)



#Main convert data json ke csv

#get_data()
#convert_data_to_file()
parsing_json()
f = open('data_beauty.json','r')
data = str(f.read())
parsed_json = json.loads(data)

# take field name
kamus = {}
for i in parsed_json['channel']:
	if(i[:-1] == 'field'):
		kamus[i] = parsed_json['channel'][i]

dataDic = []
dic = {}
for row in parsed_json['feeds']:
	for i in row:
		if(i == 'entry_id'):
			dic['id'] = row[i]
		elif(i[:-1] == 'field'):
			# if(i != 'field7') :
			# 	row[i] = float(row[i])
			dic[kamus[i]] = row[i]
	dataDic.append(dic.copy())
	
if(len(dataDic) >= 0):
	keys = dataDic[0].keys()
	with open('output_data.csv', 'w') as out:
		dict_writer = csv.DictWriter(out, keys)
		dict_writer.writeheader()
		dict_writer.writerows(dataDic)