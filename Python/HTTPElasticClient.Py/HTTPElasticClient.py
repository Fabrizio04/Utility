import requests
import json
import urllib3


class HTTPElasticClient:

    uri = ""
    index = ""
    auth_cred = ()
    verify_connect = True
    response = True

    def __init__(self, uri):
        self.uri = uri

    def CreateDocument(self, document, id):

        if self.verify_connect == False:
            urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning)

        if isinstance(self.uri, str):

            r = requests.put(f"{self.uri}/{self.index}/_doc/{id}",
                             json=document, verify=self.verify_connect, auth=self.auth_cred)

            if self.response:
                parsed = json.loads(r.text)
                print(json.dumps(parsed, indent=4, sort_keys=True))

        elif isinstance(self.uri, list):
            for uri in self.uri:

                r = requests.put(f"{uri}/{self.index}/_doc/{id}", json=document, verify=self.verify_connect, auth=self.auth_cred)

                if self.response:
                    parsed = json.loads(r.text)
                    print(uri+"\n"+json.dumps(parsed,
                          indent=4, sort_keys=True)+"\n\n")

    def DeleteDocument(self, id):

        if self.verify_connect == False:
            urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning)

        if isinstance(self.uri, str):

            r = requests.delete(f"{self.uri}/{self.index}/_doc/{id}", verify=self.verify_connect, auth=self.auth_cred)

            if self.response:
                parsed = json.loads(r.text)
                print(json.dumps(parsed, indent=4, sort_keys=True))

        elif isinstance(self.uri, list):
            for uri in self.uri:

                r = requests.delete(f"{uri}/{self.index}/_doc/{id}", verify=self.verify_connect, auth=self.auth_cred)

                if self.response:
                    parsed = json.loads(r.text)
                    print(uri+"\n"+json.dumps(parsed,
                          indent=4, sort_keys=True)+"\n\n")

    def GetDocumentById(self, id):

        if self.verify_connect == False:
            urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning)

        if isinstance(self.uri, str):

            r = requests.get(f"{self.uri}/{self.index}/_doc/{id}", verify=self.verify_connect, auth=self.auth_cred)
            parsed = json.loads(r.text)
            return parsed

        elif isinstance(self.uri, list):
            
            result = list()

            for uri in self.uri:

                r = requests.get(f"{uri}/{self.index}/_doc/{id}", verify=self.verify_connect, auth=self.auth_cred)
                parsed = json.loads(r.text)
                parsed["uri"] = uri
                result.append(parsed)
            
            return result
    
    def GetDocumentByField(self, key, value):

        if self.verify_connect == False:
            urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning)

        data = {
            "query" : {
                "match": {key: value}
            }
        }

        if isinstance(self.uri, str):

            r = requests.post(f"{self.uri}/{self.index}/_search", json=data, verify=self.verify_connect, auth=self.auth_cred)

            parsed = json.loads(r.text)
            return parsed["hits"]["hits"]

        elif isinstance(self.uri, list):

            result = list()

            for uri in self.uri:

                r = requests.post(f"{uri}/{self.index}/_search", json=data, verify=self.verify_connect, auth=self.auth_cred)
                parsed = json.loads(r.text)

                result2 = list()
                result2 = parsed["hits"]["hits"]
                result2.append(uri)
                
                result.append(parsed["hits"]["hits"])
                
            return result
