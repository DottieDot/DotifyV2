import { combineReducers } from 'redux'
import { persistReducer } from 'redux-persist'
import Auth from './Auth'
import Alerts from './Alerts'
import User from './User'
import Likes from './Likes'
import Settings from './Settings'
import storage from 'redux-persist/lib/storage'

const authPersistConfig = {
  key: 'Auth',
  storage
}

const settingsPersistConfig = {
  key: 'Settings',
  storage
}

export default combineReducers({
  Auth: persistReducer(authPersistConfig, Auth),
  Settings: persistReducer(settingsPersistConfig, Settings),
  Alerts,
  User,
  Likes,
})
