/*
Background
In this scenario, company-A has acquired company-B. Both companies were in the same markets, and in many cases they shared the same cusomers.

Company A’s User Table: dbo.users
Company B’s User Table: dbo.account_users
You are a SQL Developer whos is facilitating merging these two data sets.

You will want to avoid duplicating records when the data is merged together.

Instructions

You will be performing a migration of users from a newly acquired company.

Company A's User Table: users
Company B's User Table: account_users


1) Write a SQL statement to show matching users between the two tables.

Example Output:
Company_A_Email           Company_B_Email
_________________________ ________________________
johng@gmail.com           johng@gmail.com
Aslan@woodyhollow.org     Aslan@woodyhollow.org
oriley_peter@infocom.com  oriley_peter@infocom.com


2) Write a statement that shows users unique to Company B.

Example Output:
Company_B_Email
_____________________
hl@valve.com
kepsin@alluard.org
carie.allen@insp.org

3) Write a SQL statement that identifies those users that are NOT shared between the two tables.

Example Output:
Company_A_Email           Company_B_Email
________________          _____________________
DKS@cambridge.edu
randy.o@okloand.ru
                          hl@valve.com
                          kepsin@alluard.org

*/