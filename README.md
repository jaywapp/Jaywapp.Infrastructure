# Jaywapp.Infrastructure

Common utilities, helpers, and domain-independent reusable components used across Jaywapp projects.

## Projects

| Project | Target | Description |
|---------|--------|-------------|
| **Jaywapp.Infrastructure** | netstandard2.0 | Filtering system, helpers (Collection, DataTable, Enum, Enumerable, File, HashSet, Random, XML) |
| **Jaywapp.Common** | netstandard2.0 | Domain-independent extensions, guards, and models |

## Jaywapp.Infrastructure

### Helpers
- **CollectionHelper** - `ICollection<T>.AddRange()`
- **DataTableHelper** - `DataColumnCollection.ToList()`, `DataRowCollection.ToList()`
- **EnumHelper** - `GetValues<T>()`, `TryGetDescription()`, `GetValueFromDescription<T>()`
- **EnumerableHelper** - `IsNullOrEmpty()`, `IgnoreNull()`, `ToObservableCollection()`, `ChainPairing()`
- **FileHelper** - `ReadLines()`, `Decompress()`, `Compress()`, `ClearDirectory()`, `GetFiles()`
- **HashSetHelper** - `AddRange()`, `RemoveRange()`
- **RandomHelper** - `NextBoolean()`, `NextString()`, `NextCharacter()`, `Next<TEnum>()`, `NextColor()`
- **XmlHelper** - `GetAttributeValue()`, `TryGetAttributeValue()`, `GetAttributeValueOrEmpty()`

### Filtering System
- `IFilter` interface with `AND`/`OR` logical operators
- `Filter` - Single property filter with operators (Equal, NotEqual, LessThan, Contains, Regex, etc.)
- `FilterGroup` - Composite filter pattern for nested filter logic

## Jaywapp.Common

### Extensions
| Category | Methods |
|----------|---------|
| **StringExtensions** | `HasValue()`, `SafeTruncate()`, `ToSha256()`, `NormalizeLineEndings()` |
| **CollectionExtensions** | `IsEmpty()`, `None()`, `SafeForEach()`, `Batch()`, `DistinctBy()` |
| **TaskExtensions** | `SafeFireAndForget()`, `WithTimeout()`, `WithRetry()` |
| **DateTimeExtensions** | `StartOfDay()`, `EndOfDay()`, `IsInRange()`, `ToUtcSafe()`, `ToLocalSafe()` |
| **EnumExtensions** | `GetDescription()`, `SafeParse()`, `TryParseEnum()`, `GetValues()` |

### Guards
- `Guard.NotNull()`, `NotNullOrEmpty()`, `NotNullOrWhiteSpace()`, `InRange()`, `NotEmpty()`, `Requires()`

### Models
| Model | Description |
|-------|-------------|
| **Result / Result\<T\>** | Success/Failure pattern without exceptions |
| **Error** | Error with Code, Message, Exception, Metadata |
| **PageRequest / PageResult\<T\>** | Pagination request and response |
| **SortDefinition** | Sort field and direction |
| **Range\<T\>** | Generic comparable range with Contains/Overlaps |
| **DatePeriod** | Date range with inclusive/exclusive boundaries |
| **TreeNode\<T\>** | Generic tree with DFS/BFS traversal |
| **ChangeSet\<T\>** | Added/Updated/Removed change tracking |
| **Trackable\<T\>** | Original/Current value tracking with Accept/Reject |

## Install

```
PM> Install-Package Jaywapp.Infrastructure
```

## Build & Test

```bash
dotnet build Jaywapp.Infrastructure.sln
dotnet test Jaywapp.Infrastructure.sln
```

**Test Summary**: 168 tests (Infrastructure: 50, Common: 118) - All passing

## Solution Structure

```
Jaywapp.Infrastructure.sln
├── Jaywapp.Infrastructure/           (netstandard2.0)
├── Jaywapp.Common/                   (netstandard2.0)
├── UnitTest/
│   ├── Jaywapp.Infrastructure.Tests/ (net8.0, NUnit)
│   └── Jaywapp.Common.Tests/        (net8.0, NUnit)
└── docs/
    └── refactoring-design.md
```

## Notes

- WPF-specific types (ColorHelper, Converters) are excluded from netstandard2.0
- XML documentation is included in the package
- Jaywapp.Common has zero external dependencies

## License

[MIT](LICENSE)
