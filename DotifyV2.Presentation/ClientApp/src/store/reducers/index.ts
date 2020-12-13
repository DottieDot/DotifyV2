import { combineReducers } from 'redux'
import { persistReducer } from 'redux-persist'
import Auth from './Auth'
import Alerts from './Alerts'
import storage from 'redux-persist/lib/storage' 

const persistConfig = {
  key: 'Auth',
  storage
}

export default combineReducers({
  Auth: persistReducer(persistConfig, Auth),
  Alerts,
})
