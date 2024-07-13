import { useState, useEffect } from "react";

export default function Effect() {
    const [count, setCount] = useState(0);

    useEffect(() => {
        console.log("Component is mounted");
        console.log('Initial render');
    }, []);

    useEffect(() => {

        console.log("Component is updated");
    }, [count]);

    return (
        <>
            <h1>Effect</h1>
            <div>{count}</div>
            <button onClick={() => setCount(prevCount => prevCount + 1)}>Increment</button>
        </>
    );
}