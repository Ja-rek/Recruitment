'use strict';

async function downloadProducts() {
    toggleButton(true);
    try {
        await fetchPost('/Product/Download');
        window.location.reload();
    } catch (error) {
        console.error('Error:', error);
    } finally {
        toggleButton(false);
    }
}

async function changeState(id) {
    try {
        await fetchPost('/Product/ChangeState', { id });
        toggleState(id);
    } catch (error) {
        console.error('Error:', error);
    }
}

function toggleState(id) {
    const td = document.getElementById(`state-${id}`);
    const isIncorrect = td.className === "incorrect";
    td.className = isIncorrect ? "correct" : "incorrect";
    td.textContent = isIncorrect ? "Correct" : "Incorrect";
}

function toggleButton(disable) {
    document.getElementById("button").disabled = disable;
}

async function fetchPost(url, body = {}) {
    await fetch(url, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(body)
    });
}
