function getElementById(id) {
    return document.getElementById(id);
}

function createElement(element) {
    return document.createElement(element);
}

function createTextNode(text) {
    return document.createTextNode(text);
}

function getElementsByClassName(className){
    return document.getElementsByClassName(className);
}

var TodoList = (function () {
    function isEmptyOrWhitespace(input, errorMessage) {
        if (input == "") {
            throw new Error(errorMessage)
        }
    }

    function alreadyExist(array, name, errorMessage) {
        if (array.includes(name)) {
            throw new Error(errorMessage)
        }
    }

    function addInput(inputId, placeholderText, containerId) {
        var input = createElement("input");
        input.setAttribute("id", inputId);
        input.setAttribute("placeholder", placeholderText);
        getElementById(containerId).appendChild(input);
    }

    function addButton(buttonClassName, buttonText, containerId) {
        var button = createElement("button");
        button.setAttribute("class", buttonClassName);
        var text = createTextNode(buttonText);
        button.appendChild(text);
        getElementById(containerId).appendChild(button);
    }

    function addChildContainer(containerId, className, parentContainer) {
        var container = createElement("div");
        container.setAttribute("id", containerId);
        container.setAttribute("class", className);
        parentContainer.appendChild(container);
    }

    function formatInput(input) {
        var toLowerCase = input.toLowerCase();
        return toLowerCase.replace(" ", "-");
    }

    var containerNames = [];
    var Container = (function () {
        function Container(name) {
            this.name = name.trim();
            isEmptyOrWhitespace(this.name, "Enter valid list name.");
            alreadyExist(containerNames, this.name, "This list name already exists.");
            containerNames.push(this.name);
        }

        Container.prototype.addToDom = function () {
            var nameForId = formatInput(this.name);

            //Create container
            var container = createElement("div");
            container.setAttribute("id", "container-" + nameForId);
            container.setAttribute("class", "container");
            document.body.appendChild(container);

            //Append elements
            var h1 = createElement("h1");
            var i = createElement("i");
            var todo = createTextNode(" TODO ");
            i.appendChild(todo);
            var name = createTextNode(this.name);
            var list = createTextNode("list");
            h1.appendChild(name);
            h1.appendChild(i);
            h1.appendChild(list);
            var getContainer = getElementById("container-" + nameForId);
            getContainer.appendChild(h1);

            //Create section container
            var sectionContainer = createElement("div");
            sectionContainer.setAttribute("id", "section-container-" + nameForId);
            sectionContainer.setAttribute("class", "section-container");
            getContainer.appendChild(sectionContainer);

            var sectionContainerId = "add-section-container-" + nameForId;

            //Create add section container
            addChildContainer(sectionContainerId, "add-section-container", getContainer);

            //Create add section input
            addInput("add-section-input-" + nameForId, "Title...", sectionContainerId);

            //Create add section button
            addButton('btn', "New section", sectionContainerId);

            addSection();

        };

        return Container;
    })();

    var sectionIds = [];
    var Section = (function () {
        function Section(title, sectionContainerId, currentSection) {
            this.title = title.trim();
            isEmptyOrWhitespace(this.title, "Enter valid section title.");
            this.sectionContaineId = sectionContainerId;
            this.sectionIdName = this.sectionContaineId + "-" + this.title;
            alreadyExist(sectionIds, this.sectionIdName, "This section already exists.");
            sectionIds.push(this.sectionIdName);
            this.currentSection = currentSection;
        }

        Section.prototype.addToDom = function () {
            var sectionForId = formatInput(this.sectionIdName);

            //Create section
            var section = createElement("section");
            section.setAttribute("id", sectionForId);

            //Append section to section container
            var sectionContainer = getElementsByClassName(this.sectionContaineId)[this.currentSection];
            sectionContainer.appendChild(section);
            sectionContainer.style.border = "1px solid black";
            sectionContainer.style.padding = "10px";
            sectionContainer.style.marginBottom = "10px";

            //Add section title
            var h3 = createElement("h3");
            var text = createTextNode(this.title);
            h3.appendChild(text);
            section.appendChild(h3);

            var itemContainerId = "item-container-" + sectionForId;

            //Create add item input
            addChildContainer(itemContainerId, "add-item-container", sectionContainer);

            //Create add item input
            addInput("add-item-input-" + sectionForId, "Add item...", itemContainerId);

            //Create add item button
            addButton('btnItem', "+", itemContainerId);
        };

        return Section;
    })();

    var itemIds = [];
    var Item = (function () {
        function Item(itemName, sectionName) {
            this.itemName = itemName.trim();
            isEmptyOrWhitespace(this.itemName, "Enter valid item name.");
            this.sectionName = sectionName;
            this.itemId = this.sectionName + "-" + this.itemName;
            alreadyExist(itemIds, this.itemId, "This item already exists.");
            itemIds.push(this.itemId);

        }

        Item.prototype.addToDom = function () {
            var itemForId = formatInput(this.itemId);
            var label = createElement("label");
            var checkbox = createElement("input");
            checkbox.type = "checkbox";
            checkbox.setAttribute("id", "checkbox-" + itemForId);
            checkbox.setAttribute("onclick", "checkboxOnClick(this.id)");
            label.appendChild(checkbox);
            var span = createElement("span");
            span.setAttribute("id", "span-" + itemForId);
            span.setAttribute("class", "item-content");
            var textNodeItemName = createTextNode(this.itemName);
            span.appendChild(textNodeItemName);
            label.appendChild(span);
            getElementById(this.sectionName).appendChild(label);
        };

        return Item;
    })();

    return {
        Container: Container,
        Section: Section,
        Item: Item
    }
})();

function addParentContainer() {
    var containerName = getElementById("container-value").value;
    var container = new TodoList.Container(containerName);
    container.addToDom();
}
function print(msg){
    return console.log(msg)
}
function addSection() {
    var buttons = getElementsByClassName('btn');
    var length = buttons.length;
    for (var i = 0; i < length; i++) {
        (function(){
            var currentSection = i;
            buttons[i].addEventListener('click', function(){
                var inputValue = this.previousElementSibling.value;
                var parentContainer = this.parentNode.previousSibling.className;
                print(parentContainer)
                var section = new TodoList.Section(inputValue, parentContainer, currentSection);
                section.addToDom();
            })
        })()

    }
}


function addItem(buttonId) {
    var inputId = buttonId.replace("button", "input");
    var sectionName = buttonId.replace("add-item-button-", "");
    var itemName = getElementById(inputId).value;
    var item = new TodoList.Item(itemName, sectionName);
    item.addToDom();
}

function checkboxOnClick(checkboxId) {
    var spanId = checkboxId.replace("checkbox", "span");
    if (getElementById(checkboxId).checked) {
        getElementById(spanId).style.backgroundColor = "#90EE90";
    } else {
        getElementById(spanId).style.backgroundColor = "#FFFFFF";
    }
}




