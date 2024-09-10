import { useState } from 'react';

export function Options() {
    const [showBuilds, setShowBuilds] = useState(false);

    const weaponBuilds = [
        'Build 1',
        'Build 2',
        'Build 3',
        // Add more builds as needed
    ];

    const toggleBuilds = () => {
        setShowBuilds(!showBuilds);
    };

    return (
        <div>
            <button onClick={toggleBuilds} style={{ background: 'none', border: 'none', cursor: 'pointer' }}>
                <i className="fas fa-cog size-8"></i>
            </button>
            {showBuilds && (
                <ul>
                    {weaponBuilds.map((build, index) => (
                        <li key={index}>{build}</li>
                    ))}
                </ul>
            )}
        </div>
    );
}