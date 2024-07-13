import { useState, useEffect } from 'react';

export default function Timer() {
    const [isManual, setIsManual] = useState(false);
    const [time, setTime] = useState(() => {
        // Get the current seconds only once
        // when the component is first rendered
        const currentSeconds = new Date().getSeconds();
                
        return currentSeconds;
    });

    useEffect(() => {
      if (!isManual){
            setTimeout(() => {
                setTime(prevTime => prevTime + 1);
                setIsManual(false);
            }, 1000);
        }
    }, [time, isManual]);

    const addSecondsHandler = () => {
        setIsManual(true);
        setTime(prevTime => prevTime + 10);
    }

    return (
        <>
            <h1>Timer</h1>
            <div>{time}</div>
            <button onClick={addSecondsHandler}>Add 10 seconds</button>
        </>
    )
}