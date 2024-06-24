const {test, expect} = require('@playwright/test');

// Navigation bar for guest users
test('should display the "All Books" link', async ({page}) => {
    await page.goto('http://localhost:3000');
    
    await page.waitForSelector('.navbar');
    await expect(page.locator('text=All Books').isVisible()).resolves.toBe(true);
});

test('should display the "Log in" button', async ({page}) => {
    await page.goto('http://localhost:3000');
    await page.waitForSelector('.navbar');

    const loginButton = await page.$('a[href="/login"]');
    const isLoginButtonVisible = await loginButton.isVisible();

    expect(isLoginButtonVisible).toBe(true);
});

test('should display the "Register" button', async ({page}) => {
    await page.goto('http://localhost:3000');
    await page.waitForSelector('.navbar');

    const registerButton = await page.$('a[href="/register"]');
    const isRegisterButtonVisible = await registerButton.isVisible();

    expect(isRegisterButtonVisible).toBe(true);
});



// Navigation Bar for logged in users
test('logged in should display the "All Books" link', async ({page}) => {
    await page.goto('http://localhost:3000/login');
    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');
    await page.click('input[type="submit"]');

    await page.waitForSelector('.navbar');
    
    await expect(page.locator('a[href="/catalog"]').isVisible()).resolves.toBe(true);
});

test('logged in should display the "My Books" link', async ({page}) => {
    await page.goto('http://localhost:3000/login');
    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');
    await page.click('input[type="submit"]');

    await page.waitForSelector('.navbar');

    const myBooksLink = await page.$('a[href="/profile"]');
    const isMyBooksLinkVisible = await myBooksLink.isVisible();

    expect(isMyBooksLinkVisible).toBe(true);
});

test('logged in should display the "Add Book" link', async ({page}) => {
    await page.goto('http://localhost:3000/login');
    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');
    await page.click('input[type="submit"]');

    await page.waitForSelector('.navbar');

    const addBookLink = await page.$('a[href="/create"]');
    const isAddBookLinkVisible = await addBookLink.isVisible();

    expect(isAddBookLinkVisible).toBe(true);
});

test("logged in the User's Email Address Is Visible", async ({page}) => {
    await page.goto('http://localhost:3000/login');
    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');
    await page.click('input[type="submit"]');

    const emailAddressBlock = await page.waitForSelector('#user > span');

    const isEmailAddressBlockVisible = await emailAddressBlock.isVisible();

    expect(isEmailAddressBlockVisible).toBe(true);
});



// Log in page
test('should redirect after log in', async ({page}) => {
    await page.goto('http://localhost:3000/login');
    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');
    await page.click('input[type="submit"]');
    await page.$('a[href="/catalog"]');

    expect(page.url()).toBe('http://localhost:3000/catalog');
});

test('should throw alert mesasge after empty log in fields', async ({page}) => {
    await page.goto('http://localhost:3000/login');
    await page.click('input[type="submit"]');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toBe('alert');
        expect(dialog.message()).toBe('All fields are required!');
        await dialog.accept();
    });
    
    await page.$('a[href="/login"]');
    expect(page.url()).toBe('http://localhost:3000/login');
});

test('should throw alert mesasge after empty email log in field', async ({page}) => {
    await page.goto('http://localhost:3000/login');
    await page.fill('input[name="password"]', '123456');
    await page.click('input[type="submit"]');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toBe('alert');
        expect(dialog.message()).toBe('All fields are required!');
        await dialog.accept();
    });
    
    await page.$('a[href="/login"]');
    expect(page.url()).toBe('http://localhost:3000/login');
});

test('should throw alert mesasge after empty password log in field', async ({page}) => {
    await page.goto('http://localhost:3000/login');
    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.click('input[type="submit"]');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toBe('alert');
        expect(dialog.message()).toBe('All fields are required!');
        await dialog.accept();
    });
    
    await page.$('a[href="/login"]');
    expect(page.url()).toBe('http://localhost:3000/login');
});



// Register page







