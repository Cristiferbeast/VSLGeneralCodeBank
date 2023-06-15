typedef struct{
    int *elements;
    int size;
    int cap;
}dyn_array;

dyn_array arr;

void InitializeDynArray (dyn_array arr) {
    //Initialize Dyn Array
    arr.size = 0;
    arr.elements = calloc(1,sizeof(*arr.elements));
    arr.cap = 1;
}

void ExpandCapDynArray (dyn_array arr, int input) {
    arr.elements = realloc(arr.elements, (input + arr.cap) * sizeof(*arr.elements));
    if (arr.elements != null){
        arr.cap += input;
    }
}

void AutoExpandDynArray (dyn_array a, int input)
{
    if (arr.size < arr.cap){
        arr.elements[arr.size]= input;
        arr.size++;
    }
    else{
        printf("Need to Expand the Array")
    }
}