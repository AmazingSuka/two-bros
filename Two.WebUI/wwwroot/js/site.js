function setElementProperties(element, properties) {
    for (var prop in properties) {
        element[prop] = properties[prop]
    }

    return element
}

function appendChilds(element, childs) {
    childs.forEach(function (child) {
        element.appendChild(child)
    })
}

function appendSpinner(element) {
    let spinner = setElementProperties(document.createElement("span"), {
        className: "spinner-border spinner-border-sm ml-2"
    })

    element.appendChild(spinner)

    return spinner
}

function GetFoodDetail(id) {
    let container = $(`#foodModalContainer-${id}`)

    if (container.html().length == 0) {
        $.ajax({
            url: "/Food/Detail",
            data: `foodId=${id}`,
            dataType: 'html',
            success: function (data) {
                container.html(data)
                $(`#${id}`).modal('show');
            }
        })
    } else {
        $(`#${id}`).modal('show');
    }
};

function UpdateCartCounter() {
    $.ajax({
        url: "/Cart/Count",
        success: function (data) {
            $('#cart-count').html(data);
        }
    })
}

function AddFood(id) {
    let inp = $(`#food-input-${id}`)

    if (inp.val() == 0) {
        return; 
    }

    $.ajax({
        url: "/Cart/Set",
        data: {
            foodId: id,
            q: inp.val()
        },
        success: function () {
            UpdateCartCounter()
            if ($('#total-price')) {
                updateTotalPrice();
            }
        }
    })
}

function removeFood(id) {
    $.ajax({
        url: "/Cart/Set",
        data: {
            foodId: id,
            q: 0
        },
        success: function () {
            $(`#food-card-${id}`).hide();
            UpdateCartCounter();
            if ($('#total-price')) {
                updateTotalPrice();
            }
        }
    })
}

function incrementFoodCount(id) {
    let field = $(`#food-input-${id}`)

    field.val(+field.val() + 1)
}

function decrementFoodCount(id) {
    let field = $(`#food-input-${id}`)

    if (field.val() > 0) {
        field.val(+field.val() - 1)
    }
}

function updateQuantityField(id) {
    $.ajax({
        url: "/Cart/Quantity",
        data: {
            foodId: id
        },
        success: function (data) {
            $(`#food-input-${id}`).val(data);
            updateFullPrice(id);
        }
    });
}

function incrementQuantity(id) {
    $.ajax({
        url: "/Cart/Increment",
        data: {
            foodId: id
        },
        success: function () {
            updateQuantityField(id);
            updateTotalPrice();
            UpdateCartCounter()
        }
    });
}

function decrementQuantity(id) {
    if ($(`#food-input-${id}`).val() <= 2) {
        $(`#food-remove-${id}`).addClass('disabled');
    }
    else if ($(`#food-remove-${id}`) > 2) {
        $(`#food-remove-${id}`).removeClass('disabled');
    }

    if ($(`#food-input-${id}`).val() > 1) {
        $.ajax({
            url: "/Cart/Decrement",
            data: {
                foodId: id
            },
            success: function () {
                updateQuantityField(id);
                updateTotalPrice();
                UpdateCartCounter();
            }
        });
    }
}

function updateTotalPrice() {
    $.ajax({
        url: "/Cart/Total",
        success: function (price) {
            $('#total-price').html(`${price.toFixed(2)} руб.`);
        }
    })
}

function showOrHide(id) {
    $(`#${id}`).modal('show')
}

function getFoodCategories() {
    var categoryContainer = $('#boxters-categories');
    $.ajax({
        url: "/Food/FoodTypes",
        success: function (categories) {
            categories.forEach(function (category) {
                var dropdownItem = setElementProperties(document.createElement("a"), {
                    href: `/?category=${category.type}`,
                    innerHTML: category.type,
                    className: "dropdown-item"
                })

                categoryContainer.append(dropdownItem)
            })
        }
    })
}

function createOrderState() {
    createTableItem("/OrderState/Create");
}

function createFoodType() {
    createTableItem("/FoodType/Create");
}

function updateOrderState(id) {
    updateTableItem(id, "/OrderState/Update");
}

function updateFoodType(id) {
    updateTableItem(id, "/FoodType/Update");
}


function deleteOrderState(id) {
    deleteTableItem(id, "/OrderState/Delete");
}

function deleteFoodType(id) {
    deleteTableItem(id, "/FoodType/Delete");
}


function openToggler() {
    document.getElementById('toggle-content').classList.add("responsive");
}

function closeToggler() {
    document.getElementById('toggle-content').classList.remove("responsive");
}

function updateFullPrice(id) {
    let quantity = $(`#food-input-${id}`).val()
    let price = $(`#food-price-${id}`).html()
    console.log(id,quantity,price)
    let fullprice = price * quantity;
    document.getElementById(`fullprice-${id}`).innerHTML = `${fullprice} ₽`;
}

function changeUserRole(id) {
    let switcher = document.getElementById(`switch-role-${id}`);
    switcher.setAttribute('disabled', 'disabled');
    $.ajax({
        method: "POST",
        url: "/Account/ChangeRole",
        data: {
            id: id
        },
        success: function () {
            switcher.removeAttribute('disabled');
        },
        error: function () {
            switcher.classList.add('error');
            document.getElementById(`span-switch-${id}`).setAttribute('title', 'Сервер вернул ошибку. Перезагрузите страницу и попробуйте снова.')
        }
    })
}

// Table Control Functions
function createTableItem(url) {
    let createButton = document.getElementById(`order-state-create`)
    let spinner = appendSpinner(createButton)

    createButton.setAttribute("disabled", "disabled")

    let saveButton = setElementProperties(document.createElement("button"), {
        className: "btn btn-success mr-2",
        innerText: "Сохранить"
    })

    let cancelButton = setElementProperties(document.createElement("button"), {
        className: "btn btn-danger",
        innerText: "Отмена"
    })

    let tableCell1 = setElementProperties(document.createElement("td"), {
        innerText: "X"
    })
    let tableCell2 = document.createElement("td")
    let tableCell3 = document.createElement("td")

    let tableRow = document.createElement("tr")

    appendChilds(tableCell3, [saveButton, cancelButton])
    appendChilds(tableRow, [tableCell1, tableCell2, tableCell3])

    let table = document.getElementById("order-state-table")
    table.appendChild(tableRow)

    tableCell2.contentEditable = "true";
    tableCell2.focus()

    saveButton.onclick = function () {
        if (tableCell2.innerHTML != null) {
            $.ajax({
                method: "POST",
                url: url,
                data: {
                    value: tableCell2.innerText
                },
                success: function (data) {
                    tableRow.id = `order-state-row-${data}`

                    setElementProperties(tableCell1, {
                        id: `order-state-primary-${data}`,
                        innerText: data
                    })

                    setElementProperties(tableCell2, {
                        id: `order-state-${data}`,
                        contentEditable: "false"
                    })

                    setElementProperties(tableCell3, {
                        id: `order-state-control-${data}`,
                        innerHTML: ""
                    })

                    let updateButton = setElementProperties(document.createElement("button"), {
                        id: `update-button-${data}`,
                        className: "btn btn-warning mr-2",
                        innerHTML: "Редактировать",
                        onclick: function () {
                            updateOrderState(data)
                        }
                    })

                    let deleteButton = setElementProperties(document.createElement("button"), {
                        id: `delete-button-${data}`,
                        className: "btn btn-danger",
                        innerText: "Удалить",
                        onclick: function () {
                            deleteOrderState(data)
                        }
                    })

                    appendChilds(tableCell3, [updateButton, deleteButton])
                    spinner.remove()
                    createButton.removeAttribute("disabled")
                }
            });
        } else {
            alert("Поле должно быть заполнено!")
        }
    }

    cancelButton.onclick = function () {
        tableRow.remove()
        spinner.remove()
        createButton.removeAttribute("disabled")
    }
}

function updateTableItem (id, url) {
    let primaryField = document.getElementById(`order-state-primary-${id}`)
    let stateField = document.getElementById(`order-state-${id}`)
    let stateFieldInitValue = stateField.innerHTML
    let controlButtons = document.getElementById(`order-state-control-${id}`)
    let updateButton = document.getElementById(`update-button-${id}`)
    let deleteButton = document.getElementById(`delete-button-${id}`)

    var saveButton = setElementProperties(document.createElement("button"), {
        className: "btn btn-success mr-2",
        innerText: "Сохранить",
        onclick: function () {
            if (stateField.innerHTML != null) {
                if (stateField.innerHTML != stateFieldInitValue) {
                    $.ajax({
                        method: "POST",
                        url: url,
                        data: {
                            id: primaryField.innerText,
                            value: stateField.innerText
                        }
                    })
                }

                oldControlPanel()
            } else {
                alert("Field shouldn`t be empty")
            }
        }
    })

    var cancelButton = setElementProperties(document.createElement("button"), {
        className: "btn btn-danger",
        innerText: "Отменить",
        onclick: function () {
            stateField.innerHTML = stateFieldInitValue
            oldControlPanel()
        }
    })

    stateField.contentEditable = "true"
    stateField.focus()

    controlButtons.innerHTML = ""

    appendChilds(controlButtons, [saveButton, cancelButton])

    function oldControlPanel() {
        stateField.contentEditable = "false"
        controlButtons.innerHTML = ""
        appendChilds(controlButtons, [updateButton, deleteButton])
    }
}

function deleteTableItem(id, url) {
    if (confirm(`Удалить элемент id:${id}?`)) {
        let deleteButton = document.getElementById(`delete-button-${id}`)
        deleteButton.setAttribute("disabled", "disabled")
        let spinner = setElementProperties(document.createElement("span"), {
            className: "spinner-border spinner-border-sm ml-2"
        })

        deleteButton.appendChild(spinner)

        $.ajax({
            method: 'POST',
            url: url,
            data: {
                id: id
            },
            success: function () {
                document.getElementById(`order-state-row-${id}`).remove();
                console.log('Удалено.');
            },
            error: function (jqXHR, exception) {
                spinner.remove();
                deleteButton.removeAttribute("disabled");
                alert(`Обьект id:${id} не может быть удален. Один или несколько элементов связаны с этим объктом.`);
                console.error(exception);
            }
        })
    }
}

// -----------------------------

window.onload = function () {

    UpdateCartCounter()
    getFoodCategories()

    if ($('#total-price')) {
        updateTotalPrice();
    }
}