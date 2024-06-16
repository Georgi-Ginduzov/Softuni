--		3. Update
UPDATE Contacts
SET Website = 'www.' + LOWER(REPLACE(Authors.Name, ' ', '')) + '.com'
FROM Contacts
JOIN Authors ON Contacts.Id = Authors.ContactId
WHERE Contacts.Website IS NULL;