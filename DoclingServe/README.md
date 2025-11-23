# DoclingServe – C# Client Library

> **DoclingServe** is a lightweight C# client generated with **Kiota** that talks to the Docling Serve REST API.  
> The library is fully typed, supports JSON, multipart, form and text payloads, and is ready to be used in any .NET 6+ project.

---

## Table of Contents

| Section | Description |
|---------|-------------|
| Prerequisites | What you need to build and run the client |
| Getting the OpenAPI spec | Where the openapi.json lives |
| Generating the client | How to regenerate the code if the API changes |
| Project structure | Overview of the generated files |
| Using the client | Quick‑start example |
| Running tests | How to run the unit tests |
| Contributing | How to contribute to the project |
| License | Licensing information |

---

## Prerequisites

| Tool | Minimum version | Install |
|------|-----------------|---------|
| [.NET SDK](https://dotnet.microsoft.com/download) | 6.0 | `dotnet --version` |
| [Kiota CLI](https://github.com/microsoft/kiota) | 1.0.0 | `dotnet tool install --global Kiota` |
| Git | 2.0 | `git --version` |

> **Tip:** If you’re on Windows, you can install the .NET SDK and Kiota via the official installers or via `winget`.

---

## Getting the OpenAPI spec

The OpenAPI specification that drives the client lives in the repository root:

```
[\path to sources\Templates\DoclingServe\openapi.json](d:\Sources\Templates\DoclingServe\openapi.json)
```

If you need the latest spec from the live service, run:

```powershell
Invoke-WebRequest -Uri "https://docling-serve.example.com/openapi.json" -OutFile "openapi.json"
```

---

## Generating the client

The client is generated with Kiota. If the API changes, regenerate the code:

```powershell
# From the repository root
kiota generate -l csharp --openapi ./openapi.json -o . --class-name DoclingServe --namespace-name DoclingServe
```

> The command will overwrite the existing files in the current directory.  
> The generated files are marked with `[global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]`.

---

## Project structure

```
DoclingServe/
├─ DoclingServe.cs                     ← Entry point for the client
├─ V1/
│  ├─ V1RequestBuilder.cs             ← Root request builder
│  ├─ Status/
│  │  ├─ StatusRequestBuilder.cs
│  │  └─ Poll/
│  │     ├─ PollRequestBuilder.cs
│  │     └─ Item/
│  │        └─ WithTask_ItemRequestBuilder.cs
│  └─ Result/
│     ├─ ResultRequestBuilder.cs
│     └─ Item/
│        └─ WithTask_ItemRequestBuilder.cs
├─ Models/
│  └─ ChunkedDocumentResultItem.cs
└─ openapi.json
```

> **Links to key files**  
> - `DoclingServe.cs`  
> - `V1RequestBuilder.cs`  
> - `StatusRequestBuilder.cs`  
> - `ResultRequestBuilder.cs`  
> - `ChunkedDocumentResultItem.cs`

---

## Using the client

```csharp
using System;
using System.Threading.Tasks;
using DoclingServe;

class Program
{
    static async Task Main()
    {
        // Create the client (you can pass a custom HttpClient if needed)
        var client = new DoclingServe();

        // Example: Get the status of a job
        var status = await client.V1.Status.GetAsync();

        Console.WriteLine($"Job status: {status?.State}");

        // Example: Retrieve the result
        var result = await client.V1.Result.GetAsync();

        foreach (var item in result?.Value ?? Array.Empty<ChunkedDocumentResultItem>())
        {
            Console.WriteLine($"Chunk {item.Index}: {item.Text}");
        }
    }
}
```

> **Note:**  
> - All request builders expose `GetAsync`, `PostAsync`, etc.  
> - The generated models are in the `DoclingServe.Models` namespace.

---

## Running tests

The repository contains a test project (if present). To run the tests:

```powershell
dotnet test
```

If you need to add new tests, create a file under `Tests/` and reference the generated client.

---

## Contributing

1. Fork the repository.  
2. Create a feature branch (`git checkout -b feature/your-feature`).  
3. Make your changes.  
4. Run `dotnet test` to ensure everything passes.  
5. Submit a pull request.

---

## License

This project is licensed under the MIT License – see the LICENSE file for details.

---