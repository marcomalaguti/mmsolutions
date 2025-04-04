const API_BASE_URL = process.env.NEXT_PUBLIC_ERP_API_BASE_URL

export async function fetchData<T>(path: string, options?: RequestInit): Promise<T> {
    const url = `${API_BASE_URL}${path}`;
    const res = await fetch(url, options);
    if (!res.ok) throw new Error(`Errore API: ${res.status}`);
    return res.json();
}

export async function donwloadFile(path: string, fileName: string): Promise<void> {
    const uri = `${API_BASE_URL}${path}`;
    const res = await fetch(uri, {
        method: "GET"
    });
    if (!res.ok) throw new Error(`Errore API: ${res.status}`);
    if (!res.ok) {
        throw new Error("Failed to download file");
    }

    const blob = await res.blob();
    const url = window.URL.createObjectURL(blob);
    const a = document.createElement("a");
    a.href = url;
    a.download = fileName;
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
    window.URL.revokeObjectURL(url);
}

export async function postData<T>(path: string, body: any): Promise<T> {
    const url = `${API_BASE_URL}${path}`;
    console.log("POST URL:", url);
    const res = await fetch(url, {
        method: "POST",
        headers: {
            "Content-Type": "application/json", // Ensure JSON format
        },
        body: JSON.stringify(body)
    });
    if (!res.ok) throw new Error(`Errore API: ${res.status}`);

console.log("RES Body:", res);  

    const responseData: T = await res.json();  // Ensure it's parsed and mapped to type T
    console.log("Response:", responseData);
    return responseData;
}

export async function postFormData<T>(path: string, body: any): Promise<T> {
    const url = `${API_BASE_URL}${path}`;
    const res = await fetch(url, {
        method: "POST",
        body: body
    });
    if (!res.ok) throw new Error(`Errore API: ${res.status}`);

    const responseData: T = await res.json();  // Ensure it's parsed and mapped to type T
    console.log("Response:", responseData);

    return responseData;
}

export async function deleteData(path: string): Promise<void> {
    const url = `${API_BASE_URL}${path}`;
    const res = await fetch(url, {
        method: "DELETE"
    });
    if (!res.ok) throw new Error(`Errore API: ${res.status}`);
    return res.json();
}

