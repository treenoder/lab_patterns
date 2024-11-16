import csv
import json
import xml.etree.ElementTree as ET
from abc import ABC, abstractmethod


class DataFormat(ABC):
    @abstractmethod
    def read_data(self, file_path: str):
        pass

    @abstractmethod
    def process_data(self, data):
        pass


class CSVData(DataFormat):
    def read_data(self, file_path: str):
        print(f"Reading CSV data from {file_path}")
        with open(file_path, newline='') as csvfile:
            reader = list(csv.reader(csvfile))
        return reader

    def process_data(self, data):
        print("Processing CSV data...")
        # Приклад обробки CSV даних
        processed = [row for row in data if row]
        return processed


class JSONData(DataFormat):
    def read_data(self, file_path: str):
        print(f"Reading JSON data from {file_path}")
        with open(file_path, 'r') as jsonfile:
            data = json.load(jsonfile)
        return data

    def process_data(self, data):
        print("Processing JSON data...")
        # Приклад обробки JSON даних
        return data.get("records", [])


class XMLData(DataFormat):
    def read_data(self, file_path: str):
        print(f"Reading XML data from {file_path}")
        tree = ET.parse(file_path)
        root = tree.getroot()
        return root

    def process_data(self, data):
        print("Processing XML data...")
        # Приклад обробки XML даних
        processed = []
        for child in data:
            processed.append(child.attrib)
        return processed


class DataAnalyzer(ABC):
    def __init__(self, data_format: DataFormat):
        self.data_format = data_format

    @abstractmethod
    def analyze(self, file_path: str):
        pass


class BiologicalDataAnalyzer(DataAnalyzer):
    def analyze(self, file_path: str):
        print("Starting data analysis...")
        raw_data = self.data_format.read_data(file_path)
        processed_data = self.data_format.process_data(raw_data)
        print(f"Analyzing {len(processed_data)} records...")
        # Приклад аналізу даних
        analysis_result = f"Analysis complete. {len(processed_data)} records processed."
        return analysis_result


if __name__ == "__main__":
    # CSV файл
    csv_file = 'data.csv'
    with open(csv_file, 'w', newline='') as f:
        writer = csv.writer(f)
        writer.writerow(['id', 'value'])
        writer.writerow(['1', 'A'])
        writer.writerow(['2', 'B'])

    # JSON файл
    json_file = 'data.json'
    with open(json_file, 'w') as f:
        json.dump({"records": [{"id": 1, "value": "A"}, {"id": 2, "value": "B"}]}, f)

    # XML файл
    xml_file = 'data.xml'
    root = ET.Element("root")
    record1 = ET.SubElement(root, "record", id="1", value="A")
    record2 = ET.SubElement(root, "record", id="2", value="B")
    tree = ET.ElementTree(root)
    tree.write(xml_file)

    # Аналіз CSV даних
    csv_data = CSVData()
    csv_analyzer = BiologicalDataAnalyzer(csv_data)
    result = csv_analyzer.analyze(csv_file)
    print(result)

    print("\n-----------------\n")

    # Аналіз JSON даних
    json_data = JSONData()
    json_analyzer = BiologicalDataAnalyzer(json_data)
    result = json_analyzer.analyze(json_file)
    print(result)

    print("\n-----------------\n")

    # Аналіз XML даних
    xml_data = XMLData()
    xml_analyzer = BiologicalDataAnalyzer(xml_data)
    result = xml_analyzer.analyze(xml_file)
    print(result)

# Output:
# Starting data analysis...
# Reading CSV data from data.csv
# Processing CSV data...
# Analyzing 3 records...
# Analysis complete. 3 records processed.
#
# -----------------
#
# Starting data analysis...
# Reading JSON data from data.json
# Processing JSON data...
# Analyzing 2 records...
# Analysis complete. 2 records processed.
#
# -----------------
#
# Starting data analysis...
# Reading XML data from data.xml
# Processing XML data...
# Analyzing 2 records...
# Analysis complete. 2 records processed.
