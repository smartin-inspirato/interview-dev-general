# Rest API Code Review


A colleague is authoring a new set of APIs for Creating, Returning, Updating, and Deleting Members (customers of the system). This colleague has drawn up a quick spec on what the URLs will look like and the payloads expected. 

What comments or recommendations can you offer to make these set of APIs more Restful and adhering to the tenets of the REST paradigm? At this point, you do not have to worry about security or authentication concerns. 



***********************************
***********************************

## Purpose: Create member

URL:    {{domain}}/api/NewMember  
Verb:    POST  
Body: 
```json
      {
        "firstName": "Jane",
        "lastName": "Smith",
        "birthDate": "2018-02-08T00:00:00.000Z"
      }
```
Response:  200 Success
```json
      {
        "memberId": "1234567"
      }
```
      
---------------------------------------

## Purpose:   Retrieve existing member  
-
URL:    {{domain}}/api/NewMember?memberId=1234567  
Verb:    GET  
Body:

Response:  200 Success
```json
      {
        "memberId": "1234567",
        "firstName": "Jane",
        "lastName": "Smith",
        "birthDate": "2018-02-08T00:00:00.000Z"      
      }
```      
      
---------------------------------------

## Purpose:  Update some fields of an existing member  

URL:    {{domain}}/api/Member  
Verb:    PATCH  
Body:    
```json
      {
        "memberId": "1234567",
        "firstName": "Jane",
        "lastName": "Hall",
        "birthDate": "2018-02-08T00:00:00.000Z"
      }
```

Response:  200 Success
```json
      {
        "message" : "Updated."
      }
```      
      
---------------------------------------

## Purpose:  Delete an existing member  

URL:    {{domain}}/api/DeleteMember  
Verb:    POST  
Body:    
```json
      {
        "memberId": "1234567"
      }
```
      
Response:  200 Success
```json
      {
        "message" : "Deleted."
      }
```