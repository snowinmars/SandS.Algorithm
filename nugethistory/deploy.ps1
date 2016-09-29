function Deploy {
    param (
        [Parameter (Mandatory = $true)]
        [string] $packageName
    )

    Write-Host $packageName
}

###########

Write-Host

Write-Host "What to deploy?"

Write-Host

$dict = New-Object System.Collections.Specialized.OrderedDictionary

$dict.Add("1", "DateTime")
$dict.Add("2", "Enumerable")
$dict.Add("3", "GraphicsDevice")
$dict.Add("4", "IComparable")
$dict.Add("5", "IList")
$dict.Add("6", "StringBuilder")
$dict.Add("7", "String")
$dict.Add("8", "Bitwise")
$dict.Add("9", "Generator")
$dict.Add("a", "Graph")
$dict.Add("b", "Other")

foreach ($h in $dict.GetEnumerator()) {
    Write-Host "$($h.Name): $($h.Value)"
}

$userInput = (Read-Host).ToCharArray()

ForEach ($input in $userInput) {
    Deploy($dict.($input))
}