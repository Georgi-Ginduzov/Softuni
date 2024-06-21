const { test, expect } = require('@playwright/test');

test('user can add a task', async ({ page }) => {
    await page.goto('http://localhost:5500/05-to-do-app/');
    await page.fill('#task-input', 'Test Task');
    await page.click('#add-task');
    const taskText = await page.textContent('.task');

    expect(taskText).toContain('Test Task');
})

test('user can delete a task', async ({ page }) => {
    await page.goto('http://localhost:5500/05-to-do-app/');
    await page.fill('#task-input', 'Test Task');
    await page.click('#add-task');
    await page.click('.delete-task');
    
    const tasks = await page.$$eval('.task', tasks => tasks.map(task => task.textContent));

    expect(tasks).not.toContain('Test Task');
})

test('user can complete a task', async ({ page }) => {

    await page.goto('http://localhost:5500/05-to-do-app/');
    await page.fill('#task-input', 'Test Task');
    await page.click('#add-task');
    await page.click('.task-complete');
    
    expect(await task.getAttribute('class')).toContain('task completed');
})

test('user can filter a task', async ({ page }) => {
    await page.goto('http://localhost:5500/05-to-do-app/');
    await page.fill('#task-input', 'Test Task');
    await page.click('#add-task');
    await page.click('.task-complete');
    await page.selectOption('#filter', 'Completed');

    const incompleteTask = await page.$('.task:not(.completed)');
    
    expect(incompleteTask).toBeNull();
})