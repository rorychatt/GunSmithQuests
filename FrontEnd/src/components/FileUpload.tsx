import {ChangeEvent, useState} from "react";
import {API_URL} from "../constants.ts";

const FileUpload = () => {
    const [files, setFiles] = useState<File[]>([]);

    const handleFileChange = (e: ChangeEvent<HTMLInputElement>) => {
        if (e.target.files) {
            setFiles(Array.from(e.target.files));
        }
    };

    const handleUpload = async () => {
        if (files.length > 0) {
            console.log('Uploading files...');

            for (const file of files) {
                const formData = new FormData();
                formData.append('file', file);

                try {
                    const result = await fetch(`${API_URL}/GunParts/upload`, {
                        method: 'POST',
                        body: formData,
                    });

                    const data = await result.json();
                    console.log(data);
                } catch (error) {
                    console.error(`Error uploading file ${file.name}:`, error);
                }
            }
        }
    };

    return (
        <>
            <div className="input-group">
                <input id="file" type="file" multiple onChange={handleFileChange} />
            </div>
            {files.length > 0 && (
                <section>
                    File details:
                    <ul>
                        {files.map((file, index) => (
                            <li key={index}>
                                Name: {file.name}, Type: {file.type}, Size: {file.size} bytes
                            </li>
                        ))}
                    </ul>
                </section>
            )}

            {files.length > 0 && (
                <button
                    onClick={handleUpload}
                    className="btn"
                >Upload files</button>
            )}
        </>
    );
};

export default FileUpload;