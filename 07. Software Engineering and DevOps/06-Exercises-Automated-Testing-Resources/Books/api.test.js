const chai = require('chai');
const chaiHttp = require('chai-http');
const server = require('./server');

const expect = chai.expect;

chai.use(chaiHttp);

describe('Books', () => {
   it('should be able to create a new book', () => {
    const book = {id: `1`, title: 'The Great Gatsby', author: 'F. Scott Fitzgerald'};

    chai.request(server)
    .post('/books')
    .send(book)
    .end((err, res) => {
        if (err) {
            return done(err)      
        }

        expect(res).to.have.status(201);
        expect(res.body).to.deep.equal(book);
        
    })
   }) 

   it('should be able to get all books', () => {
    chai.request(server)
    .get('/books')
    .end((err, res) => {
        if (err) {
            return done(err)      
        }
        const book = res.body[0];

        expect(res).to.have.status(200);
        expect(book.id).to.be.equal(`1`);
        expect(book.title).to.be.equal('The Great Gatsby');
        expect(book.author).to.be.equal("F. Scott Fitzgerald");
    })
   }) 

   it('should be able to update book', () => {
    const updatedBook = {id: `1`, title: 'The Greatest Gatsby', author: 'F. Scott Fitzgerald'};

    chai.request(server)
    .put(`/books/${updatedBook.id}`)
    .send(updatedBook)
    .end((err, res) => {
        if (err) {
            return done(err)      
        }
        const book = res.body;

        expect(res.statusCode).to.be.equal(200);
        expect(book.id).to.be.equal(updatedBook.id);
        expect(book.title).to.be.equal(updatedBook.title);
        expect(book.author).to.be.equal(updatedBook.author);
        
    })
   }) 
});