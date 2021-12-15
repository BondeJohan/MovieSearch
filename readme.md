# Rubriker
# Rubrik 1
<h1>Rubrik 1</h1>

## Rubrik 2
<h2>Rubrik 2</h2>

### Rubrik 3
<h3>Rubrik 3</h3>

#### Rubrik 4
<h4>Rubrik 4</h4>

##### Rubrik 5
<h5>Rubrik 5</h5>

###### Rubrik 6
<h6>Rubrik 6</h6>

---

# Linjer

---
___
***


# Textformattering
### Markdown

*Kursiv stil*  
_Kursiv stil_  

### HTML
<em>Kursiv stil</em>
### Markdown
**Fet Stil**  
__Fet Stil__

### HTML
<strong>Fet Stil</strong> 

### Markdown
***Fet & Kursiv stil***  
___Fet & Kursiv stil___ 

### HTML
<strong><em>Fet & Kursiv stil</strong><em/> 

---
# Listor

### Onumrerade 
* First item
* Second item
* Third item

- First item
- Second item
- Third item
  - Indentering 1
    - Indentering 2
- Fourth item

### HTML

ul = unordered list
li = list item

<ul>
  <li>First item</li>  
  <li>Second item</li>
  <li>Third item</li>
  <ul>
 <li>Indetering 1</li>
</ul>

### Numrerade

1. First item
2. Second item
3. Third item
   1. Indentering
   2. Indentering
      1. Indentering
4. Fourth item 
---

# Tabeller
|Kolumn 1   |Kolumn 2   |Kolumn 3   |
|:---       |:---:      |---:       |
|1-1        |1-2        |**1-3**    |
|2-1        |2-2        |2-3        |
|3-1        |3-2        |*3-3*      |

### HTML
table
tr = table row
td = table data

<table>
<tr>
<th>Kolumn 1</th>
<th>Kolumn 2</th>
<th>Kolumn 3</th>
</tr>
<tr>
<td>1-1</td>
<td>1-2</td>
<td>1-3</td>
</tr>
<tr>
<td>2-1</td>
<td>2-2</td>
<td>3-3</td>
</tr>
<tr>
<td>3-1</td>
<td>3-2</td>
<td>3-3</td>
</tr>
</table>

--- 

# Bilder

![Logo](https://upload.wikimedia.org/wikipedia/commons/thumb/9/91/Octicons-mark-github.svg/2048px-Octicons-mark-github.svg.png "GitHuB Logo")

### HTML

src = URL  
alt = alternativ text  
title = text som syns when holding mousepointer over the image  

<img src=https://upload.wikimedia.org/wikipedia/commons/thumb/9/91/Octicons-mark-github.svg/2048px-Octicons-mark-github.svg.png alt ="logo" title="Github" ></img>


---
# Links


<https://github.com/>  
[Github](https://github.com/)

### HTML  
<a href=https://github.com/ title="GitHub" >GitHub</a>

### Referenslink

[Github Homepage]: https://github.com/

[Click Here][Github Homepage]

---
# Kodblock

```HTML
<html>
<body>
</body>
</html>
```
```csharp
public void AddSomething()
{
    if (age > 15)
    {
        // Do something....
    }
    else
    {
        // Do something
    }
}

    int age = 18;
```

---

# Indentering (block)

> Indetering  
> testing
>> Testing
