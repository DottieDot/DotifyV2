import { useTypedSelector } from '../store'
import { UserState } from '../store/model/state'

export default (): UserState => useTypedSelector(state => state.User)
