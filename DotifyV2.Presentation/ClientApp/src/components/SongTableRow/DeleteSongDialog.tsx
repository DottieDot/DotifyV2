import { Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, TextField } from '@material-ui/core'
import React, { ChangeEvent, FormEvent, useCallback, useState } from 'react'
import { useDispatch } from 'react-redux'
import { useHistory } from 'react-router'
import * as endpoints from '../../api/endpoints'
import { showAlert } from '../../store/actions/Alerts'
import { useAuthenticatedUser } from '../../hooks'

interface Props {
  open: boolean
  onClose: (deleted: boolean) => void
  songId: number
}

export default ({ open, onClose, songId }: Props) => {
  const user = useAuthenticatedUser()
  const [submitting, setSubmitting] = useState(false)
  const dispatch = useDispatch()
  const history = useHistory()

  const handleClose = useCallback(() => {
    if (!submitting) {
      onClose(false)
    }
  }, [submitting, onClose])

  const onDelete = useCallback(async () => {
    setSubmitting(true)
    const success = await endpoints.deleteSong(songId)
    if (success && user) {
      dispatch(showAlert('Song deleted', 'success'))
      setSubmitting(false)
      onClose(true)
    }
    else {
      dispatch(showAlert('Failed to delete song', 'error'))
      setSubmitting(false)
    }
  }, [setSubmitting, dispatch, history, user, songId])

  return (
    <Dialog open={open} onClose={handleClose}>
      <DialogTitle>Delete Song</DialogTitle>
      <DialogContent>
        <DialogContentText>
          Are you sure you want to delete this song?
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
