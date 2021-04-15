# Example Angular 11 with .NET
This is a simple example of to use Angular 11 and .NET together.

This application is just displaying a chart for each different company, which shows how much each of the shareholders own.
## Script to insert data into the DB: 
```sql
INSERT INTO Shareholders(Name)
VALUES('SH 1'), ('SH 2'), ('SH 3'), ('SH 4'), ('SH 5'), ('SH 6'), ('SH 7'), ('SH 8'), ('SH 9'), ('SH 15')

INSERT INTO Companies(Name)
VALUES('Oberlo'), ('Shopify'), ('Wal-Mart Stores'), ('Chevron')

INSERT INTO ShareholdersToCompanies(CompanyId, ShareholderId, Amount)
VALUES(1, 1, 50), (2, 2, 40), (1, 3, 30), (1, 4, 10), (1, 5, 8), (2, 1, 60), (1, 9, 1), (1, 8, 1)
```
