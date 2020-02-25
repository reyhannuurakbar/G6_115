import pandas as pd
import json
f = open('data_beauty.json','r') 
data = str(f.read())
parsed_json = json.loads(data)
# for x in parsed_json:
# 	print(x)
print(parsed_json['channel']['name'])
# print(json.dumps(parsed_json, indent=4, sort_keys=True))

# df = pd.read_json(r'C:\Users\Mahasiswa\Desktop\data_beauty.json')
# print(df)