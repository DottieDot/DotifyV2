import { useSelector } from 'react-redux'
import { applyMiddleware, createStore } from 'redux'
import { persistStore } from 'redux-persist'
import thunk from 'redux-thunk'
import rootReducer from './reducers'

export type RootState = ReturnType<typeof rootReducer>

export const useTypedSelector = (selector: (state: RootState) => any) => useSelector(selector)

export const store = createStore(
  rootReducer,
  applyMiddleware(
    thunk,
  )
)

export const persistor = persistStore(store)
