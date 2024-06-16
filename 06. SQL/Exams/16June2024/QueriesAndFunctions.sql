--		5.	Books by Year of Publication
--Select all books, ordered by year of publication – descending, and then by title - alphabetically.
--Required columns:
--•	Book Title
--•	ISBN
--•	YearReleased


SELECT 
		b.Title AS 'Book Title',
		b.ISBN,
		b.YearPublished AS YearReleased
FROM Books AS b
ORDER BY b.YearPublished DESC, b.Title ASC


--		6.	Books by Genre
--Select all books with 'Biography' or 'Historical Fiction' genres. Order results by Genre, and then by book title – alphabetically.
--  Required columns:
--•	Id
--•	Title
--•	ISBN
--•	Genre

SELECT 
		b.Id,
		b.Title,
		b.ISBN,
		g.Name AS Genre
FROM Books AS b
JOIN Genres AS g ON 
	b.GenreId = g.Id 
	WHERE g.Name IN ('Biography', 'Historical Fiction')
ORDER BY g.Name ASC, b.Title ASC


--		7.	Libraries Missing Specific Genre
--Select all libraries that do not have any books of a specific genr('Mystery'). Order the results by the name of thelibrary in	ascending order.
--Required columns:
--•	Library
--•	Email

SELECT 
    l.Name AS Library,
    c.Email
FROM 
    Libraries l
JOIN 
    Contacts c ON l.ContactId = c.Id
WHERE 
    l.Id NOT IN (
        SELECT 
            lb.LibraryId
        FROM 
            LibrariesBooks lb
        JOIN 
            Books AS b ON lb.BookId = b.Id
        JOIN 
            Genres AS g ON b.GenreId = g.Id
        WHERE 
            g.Name = 'Mystery'
    )
ORDER BY 
    l.Name ASC;

--		8.	First 3 Books
--Your task is to write a query to select the first 3 books from the library database (LibraryDb) that meet the following criteria:
--•	The book was published after the year 2000 and contains the letter 'a' in the book title, 
--•	OR
--•	The book was published before 1950 and the genre name contains the word 'Fantasy'.
--The results should be ordered by the book title in ascending order, and then by theyear published in descending order.
--Required columns:
--•	Title
--•	Year
--•	Genre

SELECT TOP 3
		b.Title,
		b.YearPublished AS 'Year',
		g.Name AS Genre
FROM Books AS b
JOIN Genres AS g ON b.GenreId = g.Id
	WHERE (b.YearPublished > 2000 AND b.Title LIKE'%a%') OR
		  (b.YearPublished < 1950 AND g.Name LIKE '%Fantasy%')
ORDER BY b.Title ASC, b.YearPublished DESC


--		9.	Authors from the UK
SELECT 
		a.Name AS Author,
		c.Email,
		c.PostAddress AS Adress
FROM Authors AS a
JOIN Contacts AS c ON a.ContactId = c.Id
WHERE c.PostAddress LIKE '%UK%'
ORDER BY a.Name ASC


--		10. Memoirs in NY
SELECT 
		a.Name AS Author,
		b.Title,
		l.Name AS Library,
		c.PostAddress AS 'Library Address'
FROM Books AS b
JOIN Authors AS a ON b.AuthorId = a.Id
JOIN LibrariesBooks AS lb ON b.Id = lb.BookId
JOIN Libraries AS l ON lb.LibraryId = l.Id
JOIN Contacts AS c ON l.ContactId = c.Id
JOIN Genres AS g ON b.GenreId = g.Id
WHERE c.PostAddress LIKE'%Denver%' AND g.Name = 'Fiction'
ORDER BY b.Title ASC

SELECT DISTINCT
		Name 
FROM Genres



--		12. Create a user-defined function, named udf_AuthorsWithBooks(@name) that receives an author's- -name.
--•	The function will accept an author's name as a parameter
--•	It will join the relevant tables to count the total number of books by that author --available in all libraries


CREATE FUNCTION udf_AuthorsWithBooks(@name NVARCHAR(100))
RETURNS INT
AS
BEGIN
    DECLARE @bookCount INT;

    SELECT @bookCount = COUNT(*)
    FROM Authors a
    JOIN Books b ON a.Id = b.AuthorId
    WHERE a.Name = @name;

    RETURN @bookCount;
END;



-- Stored procedure to search books by genre and order them alphabetically by title
CREATE PROCEDURE usp_SearchByGenre @genreName NVARCHAR(30)
AS
BEGIN
    SELECT 
        b.Title,
        b.YearPublished AS Year,
        b.ISBN,
        a.Name AS Author,
        g.Name AS Genre
    FROM Books b
    JOIN Authors AS a ON b.AuthorId = a.Id
    JOIN Genres AS g ON b.GenreId = g.Id
    WHERE g.Name = @genreName
    ORDER BY b.Title ASC;
END;

EXEC usp_SearchByGenre 'Fantasy';
