import { Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, TextField } from '@material-ui/core'
import React, { ChangeEvent, FormEvent, useCallback, useState } from 'react'
import { useDispatch } from 'react-redux'
import { useHistory } from 'react-router'
import * as endpoints from '../../api/endpoints'
import { showAlert } from '../../store/actions/Alerts'
import { setUserArtistId } from '../../store/actions/User'
import { useAuthenticatedUser } from '../../hooks'

interface Props {
  open: boolean
  onClose: () => void
  albumId: number
}

export default ({ open, onClose, albumId }: Props) => {
  const user = useAuthenticatedUser()
  const [submitting, setSubmitting] = useState(false)
  const dispatch = useDispatch()
  const history = useHistory()

  const handleClose = useCallback(() => {
    if (!submitting) {
      onClose()
    }
  }, [submitting, onClose])

  const onDelete = useCallback(async () => {
    setSubmitting(true)
    const success = await endpoints.deleteAlbum(albumId)
    if (success && user) {
      dispatch(showAlert('Album deleted', 'success'))
      setSubmitting(false)
      handleClose()
      history.replace(`/artists/${user?.artist_id}`)
    }
    else {
      dispatch(showAlert('Failed to delete album', 'error'))
      setSubmitting(false)
    }
  }, [setSubmitting, dispatch, history, user, albumId])

  return (
    <Dialog open={open} onClose={handleClose}>
      <DialogTitle>Delete Album</DialogTitle>
      <DialogContent>
        <DialogContentText>
          Are you sure you want to delete this album?
        </DialogContentText>
      </DialogContent>
      <DialogActions>
        <Button
          disabled={submitting}
          onClick={handleClose}
          color="primary"
        >
          Cancel
        </Button>
        <Button
          disabled={submitting}
          onClick={onDelete}
          type="submit"
          color="primary"
        >
          Delete
        </Button>
      </DialogActions>
    </Dialog>
  )
}
