import { Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, TextField } from '@material-ui/core'
import React, { ChangeEvent, FormEvent, useCallback, useState } from 'react'
import { useDispatch } from 'react-redux'
import { useHistory } from 'react-router'
import * as endpoints from '../../api/endpoints'
import { showAlert } from '../../store/actions/Alerts'

interface Props {
  open: boolean
  onClose: (name: string | null, duration: number | null) => void
  currentName: string
  currentDuration: number
  songId: number
}

export default ({ open, onClose, currentName, currentDuration, songId }: Props) => {
  const [name, setName] = useState('')
  const [duration, setDuration] = useState<number|string>('')
  const [submitting, setSubmitting] = useState(false)
  const dispatch = useDispatch()
  const history = useHistory()

  const handleClose = useCallback(() => {
    if (!submitting) {
      onClose(null, null)
      setName('')
      setDuration('')
    }
  }, [submitting, onClose, setName])

  const onNameChange = useCallback((event: ChangeEvent<HTMLInputElement>) => {
    setName(event.target.value)
  }, [setName])

  const onDurationChange = useCallback((event: ChangeEvent<HTMLInputElement>) => {
    setDuration(event.target.value)
  }, [setDuration])

  const onSubmit = useCallback(async (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault()
    setSubmitting(true)
    const success = await endpoints.updateSong(songId, name, +duration)
    if (success) {
      dispatch(showAlert('Updated song', 'success'))
      setSubmitting(false)
      setName('')
      setDuration('')
      onClose(name, +duration)
    }
    else {
      dispatch(showAlert('Failed to update song', 'error'))
      setSubmitting(false)
    }
  }, [setSubmitting, name, history, dispatch, duration])

  return (
    <Dialog open={open} onClose={handleClose}>
      <form onSubmit={onSubmit}>
        <DialogTitle>Update Song</DialogTitle>
        <DialogContent>
          <DialogContentText>
            Enter a new name and duration for the song.
          </DialogContentText>
          <TextField
            margin="dense"
            label="Name"
            type="text"
            placeholder={currentName}
            value={name}
            onChange={onNameChange}
            disabled={submitting}
            required
            fullWidth
          />
          <TextField
            margin="dense"
            label="Duration"
            type="text"
            placeholder={currentDuration.toString()}
            value={duration}
            onChange={onDurationChange}
            disabled={submitting}
            required
            fullWidth
          />
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
            disabled={!name.trim() || (duration === '') || submitting}
            type="submit"
            color="primary"
          >
            Save
          </Button>
        </DialogActions>
      </form>
    </Dialog>
  )
}
