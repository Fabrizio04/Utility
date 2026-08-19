# HTTPElasticClient.Py

## HTTPElasticClient è una classe Python basata sulle Elastic REST APIs, per la gestione di base (inserimento, aggiornamento, cancellazione e ricerca) dei documenti di un Server Elasticsearch

### Requisiti

- requests
- json
- urllib3

### Esempio

```python
from HTTPElasticClient import HTTPElasticClient
import json

elastic = HTTPElasticClient("https://192.168.1.64:9200")
elastic.verify_connect = False
elastic.auth_cred = ("username", "password")
elastic.response = True
elastic.index = "persone"

nuovaPersona = {
    "id": "001",
    "nome": "Fabrizio",
    "cognome": "Amorelli"
}

try:
    
    elastic.CreateDocument(nuovaPersona, nuovaPersona["id"])
    persona = elastic.GetDocumentByField("cognome","Amorelli")
    print(json.dumps(persona, indent=4, sort_keys=True))

except Exception as e:
    print(e.args)
```

### Lista attributi disponibili

- uri: str / list

- index: str

- auth_cred: tuple(username: string, password: string)

- verify_connect: bool

- response: bool

### Lista metodi disponibili

- HTTPElasticClient(uri: str): costruttore

- HTTPElasticClient(uri: list): costruttore

- CreateDocument(document, id): void

- DeleteDocument(id): void

- GetDocumentById(id): object / list<object>

- GetDocumentByField(key, value): list<object> / list(list<object>)
