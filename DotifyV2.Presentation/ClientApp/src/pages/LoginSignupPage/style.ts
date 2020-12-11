import { makeStyles } from '@material-ui/core'

export default makeStyles(theme => ({
  container: {
    paddingTop: theme.spacing(2)
  },
  card: {
    height: '100%',
  },
  cardContent: {
    height: '100%',
    display: 'flex',
    flexDirection: 'column',
    flex: 1,
  },
  form: { 
    display: 'inline-flex', 
    flexDirection: 'column', 
    flex: 1, 
  },
  gap: {
    flex: 1,
    minHeight: theme.spacing(2),
  },
  errorText: {
    color: theme.palette.error.main
  }
}))
