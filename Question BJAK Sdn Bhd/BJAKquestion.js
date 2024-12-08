function regularizeNames(nameArray) {

    if (nameArray.length === 0) {
      return "";
    }

    const regularizedNames = nameArray.map(name => {
      name = name.trim();
      name = name.charAt(0).toUpperCase() + name.slice(1);
      name = name.replace(/\s+/g, " ");
  
      return name;
    });
    return regularizedNames.join(", ");
  }

  const names = ['" mr trogers "', "Tim sm ith"];
  const regularizedNames = regularizeNames(names);
  console.log(regularizedNames); // Expected Output: "Rogers, Tim Smith"