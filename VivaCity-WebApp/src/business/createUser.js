export default async function createUser(pseudo) {
    /*const res = await fetch('http://localhost:5130/api/Users', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            pseudo : pseudo
        })
    });

    if (!res.ok) {
        throw new Error('Failed to create user');
    }

    const text = await res.text();
    console.log(text); */
    console.log("ok")
    return await response.json();
}
