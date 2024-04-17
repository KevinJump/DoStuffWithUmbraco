## Code principles & tips.

Throughout this repo we have tried to stick to some basic principles and patterns for a clean and easy to navigate solution.

Many of these tips are not Umbraco specific, just things that make working on top of the Umbraco code base simpler and less error prone.

## is false, is true, is null over !, blank and == null

where possible using `is null` and other `is` methods makes the code more readable
and its easier to see what something is doing.

e.g

```cs
if (UserCanSeeThePage(user) is false) return;
```

**over**

```cs
if (!UserCanSeeThePage(user)) return;
```

it's very easy to miss the !

## Minimal nesting

I am not a complete no-nester - but reducing the number of nested calls does make the code simpler to read.

where possible we prefere breaking or returning out of a method or loop over nested the code.

```cs
if (SomethingCanBeDone() is false) return

// do something
```

**over**

```cs
if (SomethingCanBeDone()) {
    // do something
}
```

### Similary for loops

```cs
foreach(var item in listOfItems) {

    if (IsItemEnabled() is false) continue;

    // do work if item is enabled
}
```

**over**

```cs
foreach(var item in listOfItems) {

    if (IsItemEnabled()) {
        // do things
    }
}
```

## Null if something is missing.

Using 'Nullable' setup, we return null if something is missing, this makes the code consistant, checking for blank or empty can be a bit more combersome, checking for null works with the compiler to help eliminate errors.

```cs
public string? GetNameFromUser(User? user)
```

## Never null a collection

If you know that a collection is never null, you can have cleaner code, because you can
for example always have a `foreach` on your result without having check for null.

returning Enumerable.Empty or equivalant will mean that the compiler and garbage collection will ensure you don't end up with additional memory calls.

e.g

```cs
public IEnumerable<Items> GetSomeItems(string searchPattern)

    // do some work

    return items ?? [];
}
```

### Other things

As we remember what they are.
