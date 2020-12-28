
export default <T extends Object, K extends keyof T>(obj: T, key: K): T => 
  Object.keys(obj).reduce<T>((accumulator, k) => {
    if (k !== key.toString()) {
      accumulator[k as K] = obj[k as K]
    }
    return accumulator
  }, {} as T)
