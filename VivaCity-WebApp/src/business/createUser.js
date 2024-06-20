export default async function createUser(username) {
    const response = await fetch('/api/users', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ username })
    });

    if (!response.ok) {
        throw new Error('Failed to create user');
    }

    return await response.json();
}
