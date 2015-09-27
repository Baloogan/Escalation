function retrocycle(obj) {
    var catalog = [];
    catalogObject(obj, catalog);
    resolveReferences(obj, catalog);
}

function catalogObject(obj, catalog) {
    var i;
    if (obj && typeof obj === 'object') {
        var id = obj.$id;
        if (typeof id === 'string') {
            catalog[id] = obj;
        }
        if (Object.prototype.toString.apply(obj) === '[object Array]') {
            for (i = 0; i < obj.length; i += 1) {
                catalogObject(obj[i], catalog);
            }
        } else {
            for (name in obj) {
                if (typeof obj[name] === 'object') {
                    catalogObject(obj[name], catalog);
                }
            }
        }
    }
}

function resolveReferences(obj, catalog) {
    var i, item, name, id;
    if (obj && typeof obj === 'object') {
        if (Object.prototype.toString.apply(obj) === '[object Array]') {
            for (i = 0; i < obj.length; i += 1) {
                item = obj[i];
                if (item && typeof item === 'object') {
                    id = item.$ref;
                    if (typeof id === 'string') {
                        obj[i] = catalog[id];
                    } else {
                        resolveReferences(item, catalog);
                    }
                }
            }
        } else {
            for (name in obj) {
                if (typeof obj[name] === 'object') {
                    item = obj[name];
                    if (item) {
                        id = item.$ref;
                        if (typeof id === 'string') {
                            obj[name] = catalog[id];
                        } else {
                            resolveReferences(item, catalog);
                        }
                    }
                }
            }
        }
    }
}





















/*
    cycle.js
    2015-02-25

    Public Domain.

    NO WARRANTY EXPRESSED OR IMPLIED. USE AT YOUR OWN RISK.

    This code should be minified before deployment.
    See http://javascript.crockford.com/jsmin.html

    USE YOUR OWN COPY. IT IS EXTREMELY UNWISE TO LOAD CODE FROM SERVERS YOU DO
    NOT CONTROL.
*/

/*jslint eval, for */

/*property 
    $ref, apply, call, decycle, hasOwnProperty, length, prototype, push,
    retrocycle, stringify, test, toString
*/

if (typeof JSON.decycle !== 'function') {
    JSON.decycle = function decycle(object) {
        'use strict';

        // Make a deep copy of an object or array, assuring that there is at most
        // one instance of each object or array in the resulting structure. The
        // duplicate references (which might be forming cycles) are replaced with
        // an object of the form
        //      {$ref: PATH}
        // where the PATH is a JSONPath string that locates the first occurance.
        // So,
        //      var a = [];
        //      a[0] = a;
        //      return JSON.stringify(JSON.decycle(a));
        // produces the string '[{"$ref":"$"}]'.

        // JSONPath is used to locate the unique object. $ indicates the top level of
        // the object or array. [NUMBER] or [STRING] indicates a child member or
        // property.

        var objects = [],   // Keep a reference to each unique object or array
            paths = [];     // Keep the path to each unique object or array

        return (function derez(value, path) {

            // The derez recurses through the object, producing the deep copy.

            var i,          // The loop counter
                name,       // Property name
                nu;         // The new object or array

            // typeof null === 'object', so go on if this value is really an object but not
            // one of the weird builtin objects.

            if (typeof value === 'object' && value !== null &&
                    !(value instanceof Boolean) &&
                    !(value instanceof Date) &&
                    !(value instanceof Number) &&
                    !(value instanceof RegExp) &&
                    !(value instanceof String)) {

                // If the value is an object or array, look to see if we have already
                // encountered it. If so, return a $ref/path object. This is a hard way,
                // linear search that will get slower as the number of unique objects grows.

                for (i = 0; i < objects.length; i += 1) {
                    if (objects[i] === value) {
                        return { $ref: paths[i] };
                    }
                }

                // Otherwise, accumulate the unique value and its path.

                objects.push(value);
                paths.push(path);

                // If it is an array, replicate the array.

                if (Object.prototype.toString.apply(value) === '[object Array]') {
                    nu = [];
                    for (i = 0; i < value.length; i += 1) {
                        nu[i] = derez(value[i], path + '[' + i + ']');
                    }
                } else {

                    // If it is an object, replicate the object.

                    nu = {};
                    for (name in value) {
                        if (Object.prototype.hasOwnProperty.call(value, name)) {
                            nu[name] = derez(value[name],
                                    path + '[' + JSON.stringify(name) + ']');
                        }
                    }
                }
                return nu;
            }
            return value;
        }(object, '$'));
    };
}

