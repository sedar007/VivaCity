export default async function postLogin(username) {
    const res = await fetch('https://m1.dysnomia.studio/api/Users/auth', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            username: username
        })
    });

    if(res.status !== 200) {
        throw new Error('Erreur lors de l\'auth');
    }

    const text = await res.text();
    //const jsObject = await res.json();
    console.log(text);

    return text;
}