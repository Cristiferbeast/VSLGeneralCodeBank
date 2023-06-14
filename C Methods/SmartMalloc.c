void* SmartMalloc(void** ptr, int x)
{
    *ptr = malloc( x * sizeof(**ptr));
    if (*ptr != NULL) {
        return *ptr;
    }
    else {
        printf("Malloc Failed, Memory Unable to Be Accessed\n");
        return NULL;
    }
}