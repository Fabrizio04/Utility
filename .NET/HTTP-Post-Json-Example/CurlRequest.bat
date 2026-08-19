@echo off
SETLOCAL ENABLEEXTENSIONS
SETLOCAL ENABLEDELAYEDEXPANSION

curl -X POST -u username:password -k http://192.168.1.45:9200/ -H "Content-Type: application/json; charset=UTF-8" -d @input.json
