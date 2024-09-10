import {Canvas} from "@react-three/fiber";
import {Suspense} from "react";
import {OrbitControls} from "@react-three/drei";

export function Main() {
    return (
        <main className="flex flex-col items-center justify-center text-center">
            <Canvas className="border-2 border-gray-300 rounded-lg p-2" gl={{ alpha: false }} style={{ background: '#e0f7fa' }}>
                <Suspense fallback={null}>
                    <ambientLight intensity={0.5} />
                    <pointLight position={[10, 10, 10]} />
                    <directionalLight position={[5, 5, 5]} intensity={1} />
                    <spotLight position={[-5, 5, 5]} angle={0.3} penumbra={1} intensity={1} castShadow />
                    <mesh>
                        <boxGeometry args={[1, 1, 1]} />
                        <meshStandardMaterial color="orange" />
                    </mesh>
                    <OrbitControls />
                </Suspense>
            </Canvas>
        </main>
    );
}