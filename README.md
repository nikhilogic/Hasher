# Hasher
This application calculates the MD5, SHA-1 & SHA-256 hashes of the file (input) and  compares them to the hashes pasted.
This is a quick way to check the hashes for any files downloaded from the internet.

On Windows 10 you can add a short cut in your context menu by editing the registry as shown:

1. Create following keys as shown if not already existing
```
    HKEY_CLASSES_ROOT
        --*
            --shell
                --Hasher
                    --command
```
2. Under command key edit the "Default" string to have this value 
```shell
"cmd /K \"dotnet {path_to_hasherdll}\\Hasher.dll \"%1\"\""
```
_where {path_to_hasherdll} is the directory location of the Hasherdll._

