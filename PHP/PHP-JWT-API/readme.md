PHP-JWT-API
=======
Script esempio di Test per autenticazione JWT API

Requisiti
------------

- Ultima versione PHP
- Composer (facoltativo)
- JWT (Firebase)

Per installare la libreria php-jwt di Firebase

```bash
composer require firebase/php-jwt
```

Può anche essere installata manualmente

Link

- [JWT](https://jwt.io)
- [Composer](https://getcomposer.org/)
- [Firebase PHP-JWT](https://github.com/firebase/php-jwt)

Esempio
-------

#### POST JSON index.php

```json
{
    "utente":"mionomeutente",
    "password":"miapassword"
}
```

#### GET api.php

```header
"Authorization":"miotokenjwt"
```