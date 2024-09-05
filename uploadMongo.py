from pymongo import MongoClient
import json
import sys
import os

def save_to_mongodb(file_path, uri, db_name, collection_name):
	if not os.path.exists(file_path):
        raise FileNotFoundError(f"File not found: {file_path}")

    with open(file_path, 'r') as file:
        json_data = file.read()

    # Connect to MongoDB
    client = MongoClient(uri)
    db = client[db_name]
    collection = db[collection_name]

    # Convert JSON string to Python dictionary
    data = json.loads(json_data)

    # Insert the data into the collection
    collection.insert_one(data)

if __name__ == "__main__":
    file_path = sys.argv[1]
    uri = sys.argv[2]
    db_name = sys.argv[3]
    collection_name = sys.argv[4]

    save_to_mongodb(file_path, uri, db_name, collection_name)
