import { useEffect, useMemo } from 'react'
import { useDispatch } from 'react-redux'
import { useSnackbar } from 'notistack'
import { useAlerts } from './hooks'
import { removeAlert } from './store/actions/Alerts'

let displayed: number[] = []

const Notifier = () => {
  const dispatch = useDispatch()
  const alerts = useAlerts()
  const { enqueueSnackbar, closeSnackbar } = useSnackbar()

  const notifications = useMemo(() => {
    return Object.keys(alerts).map(id => alerts[+id])
  }, [alerts])

  const storeDisplayed = (id: number) => {
    displayed = [...displayed, id]
  }

  const removeDisplayed = (id: number) => {
    displayed = [...displayed.filter(key => id !== key)]
  }

  useEffect(() => {
    notifications.forEach(({ id, message, sevirity }) => {
      if (displayed.includes(id)) return

      enqueueSnackbar(message, {
        key: id,
        variant: sevirity,
        onClose: (_event, _reason, id) => {

        },
        onExited: (_event, id) => {
          dispatch(removeAlert(+id))
          removeDisplayed(+id)
        },
      })

      storeDisplayed(id)
    })
  }, [notifications, closeSnackbar, enqueueSnackbar, dispatch])

  return null
}

export default Notifier
