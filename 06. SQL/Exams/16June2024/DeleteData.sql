--		4. DELETE
DELETE lb
FROM LibrariesBooks lb
JOIN Books b ON lb.BookId = b.Id
JOIN Authors a ON b.AuthorId = a.Id
WHERE a.Name = 'Alex Michaelides';

DELETE b
FROM Books b
JOIN Authors a ON b.AuthorId = a.Id
WHERE a.Name = 'Alex Michaelides';

DELETE FROM Authors
WHERE Name = 'Alex Michaelides';